// fnt2sad — Convert BMFont .fnt + .png to SadConsole .font + .png
//
// Usage:
//   fnt2sad myfont.fnt myfont.png                       → myfont_out.font + myfont_out.png + myfont_map.cs
//   fnt2sad myfont.fnt myfont.png MyGameFont            → MyGameFont.font + MyGameFont.png + MyGameFont_map.cs
//
// Generates a regular-grid PNG (SadConsole requires uniform cells) from BMFont's packed layout,
// and a C# helper file that maps characters to glyph indices.

using SkiaSharp;

if (args.Length < 2)
{
    Console.WriteLine("用法: fnt2sad <file.fnt> <file.png> [输出名前缀]");
    Console.WriteLine("示例: fnt2sad myfont.fnt myfont.png MyFont");
    return 1;
}

string fntFile = args[0];
string pngFile = args[1];
string outName = args.Length > 2 ? args[2] : Path.GetFileNameWithoutExtension(fntFile) + "_out";

if (!File.Exists(fntFile)) { Console.WriteLine($"fnt 文件不存在: {fntFile}"); return 1; }
if (!File.Exists(pngFile)) { Console.WriteLine($"png 文件不存在: {pngFile}"); return 1; }

// ------- 1. 解析 .fnt 文本格式 -------
var lines = File.ReadAllLines(fntFile);
int lineHeight = 0, scaleW = 0, scaleH = 0;
var charEntries = new List<(int id, int x, int y, int w, int h, int xadv)>();

foreach (var line in lines)
{
    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 0) continue;

    var dict = new Dictionary<string, string>();
    foreach (var part in parts[1..])
    {
        int eq = part.IndexOf('=');
        if (eq > 0)
            dict[part[..eq]] = part[(eq + 1)..].Trim('"');
    }

    if (parts[0] == "common" && dict.TryGetValue("lineHeight", out var lh))
    {
        lineHeight = int.Parse(lh);
        scaleW = dict.TryGetValue("scaleW", out var sw) ? int.Parse(sw) : 0;
        scaleH = dict.TryGetValue("scaleH", out var sh) ? int.Parse(sh) : 0;
    }
    else if (parts[0] == "chars" && dict.TryGetValue("count", out var count))
    {
        Console.WriteLine($"字符总数: {count}");
    }
    else if (parts[0] == "char")
    {
        int id = dict.TryGetValue("id", out var sid) ? int.Parse(sid) : 0;
        int x  = dict.TryGetValue("x", out var sx)  ? int.Parse(sx) : 0;
        int y  = dict.TryGetValue("y", out var sy)  ? int.Parse(sy) : 0;
        int w  = dict.TryGetValue("width", out var sw2)   ? int.Parse(sw2) : 0;
        int h  = dict.TryGetValue("height", out var sh2)  ? int.Parse(sh2) : 0;
        int xa = dict.TryGetValue("xadvance", out var sa) ? int.Parse(sa) : w;

        charEntries.Add((id, x, y, w, h, xa));
    }
}

if (charEntries.Count == 0) { Console.WriteLine("fnt 文件中没有字符数据"); return 1; }
if (lineHeight == 0)        { Console.WriteLine("未找到 lineHeight"); return 1; }

// ------- 2. 计算 SadConsole 网格参数 -------
int glyphW = charEntries.Max(c => c.xadv);
int glyphH = lineHeight;
int columns = 16; // 标准 16 列
int rows = (int)Math.Ceiling((double)charEntries.Count / columns);
int outputW = columns * glyphW;
int outputH = rows * glyphH;

Console.WriteLine($"网格: {columns}×{rows}, 格子: {glyphW}×{glyphH}, PNG: {outputW}×{outputH}");

// ------- 3. 读取源 PNG，把每个字形重排到规则网格中 -------
using var srcBmp = SKBitmap.Decode(pngFile);
if (srcBmp == null) { Console.WriteLine("无法读取 PNG"); return 1; }

using var surface = SKSurface.Create(new SKImageInfo(outputW, outputH));
var canvas = surface.Canvas;
canvas.Clear(SKColors.Transparent);

for (int i = 0; i < charEntries.Count; i++)
{
    var (_, sx, sy, sw, sh, _) = charEntries[i];
    if (sw == 0 || sh == 0) continue;

    int cx = i % columns;
    int cy = i / columns;
    int dx = cx * glyphW + (glyphW - sw) / 2;
    int dy = cy * glyphH + glyphH - sh;

    canvas.DrawBitmap(srcBmp,
        new SKRectI(sx, sy, sx + sw, sy + sh),
        new SKRect(dx, dy, dx + sw, dy + sh));
}

using var dstImg = surface.Snapshot();
using var pngData = dstImg.Encode(SKEncodedImageFormat.Png, 100);
File.WriteAllBytes($"{outName}.png", pngData.ToArray());

// ------- 4. 找 SolidGlyphIndex（实心方块 U+2588 = 9608） -------
int solidIndex = charEntries.FindIndex(c => c.id == 0x2588);
if (solidIndex < 0) solidIndex = charEntries.FindIndex(c => c.id == 219); // IBM扩展方块
if (solidIndex < 0) solidIndex = 0;

// ------- 5. 写 .font JSON -------
var fontJson = $$"""
{
  "$type": "SadConsole.SadFont, SadConsole",
  "Name": "{{outName}}",
  "FilePath": "{{outName}}.png",
  "GlyphHeight": {{glyphH}},
  "GlyphPadding": 0,
  "GlyphWidth": {{glyphW}},
  "SolidGlyphIndex": {{solidIndex}},
  "Columns": {{columns}}
}

""";
File.WriteAllText($"{outName}.font", fontJson);

// ------- 6. 生成字符映射 C# 文件 -------
var mapLines = new List<string>
{
    "// 字符 → 字形索引映射表（自动生成）",
    "// 用法: GlyphIndex[ch] 或 TryGetValue(ch, out idx)",
    "",
    $"// 字体: {outName}",
    $"// 网格: {columns}×{rows}, 格子: {glyphW}×{glyphH}",
    $"// 生成时间: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
    "",
    "using System.Collections.Generic;",
    "",
    "static class CharToGlyph",
    "{",
    $"    public static readonly IReadOnlyDictionary<char, int> Map = new Dictionary<char, int>",
    "    {",
};

for (int i = 0; i < charEntries.Count; i++)
{
    char ch = (char)charEntries[i].id;
    string key = ch switch
    {
        '\\' => @"'\\'",
        '\'' => @"'\''",
        <= ' ' or >= '\u007f' => $"(char)0x{charEntries[i].id:X4}",
        _ => $"'{ch}'"
    };
    mapLines.Add($"        [{key}] = {i},");
}

mapLines.Add("    };");
mapLines.Add("}");

File.WriteAllLines($"{outName}_map.cs", mapLines);

Console.WriteLine($"OK! 生成:");
Console.WriteLine($"  {outName}.font");
Console.WriteLine($"  {outName}.png");
Console.WriteLine($"  {outName}_map.cs");
return 0;
