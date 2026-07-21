// 字符 → 字形索引映射表（自动生成）
// 用法: GlyphIndex[ch] 或 TryGetValue(ch, out idx)

// 字体: GameFont
// 网格: 16×2, 格子: 16×18
// 生成时间: 2026-07-21 17:39:25

using System.Collections.Generic;

static class CharToGlyph
{
    public static readonly IReadOnlyDictionary<char, int> Map = new Dictionary<char, int>
    {
        [(char)0x0000] = 0,
        [(char)0x0020] = 1,
        [(char)0x4E00] = 2,
        [(char)0x4E0B] = 3,
        [(char)0x4F5C] = 4,
        [(char)0x5165] = 5,
        [(char)0x5230] = 6,
        [(char)0x5C42] = 7,
        [(char)0x5E01] = 8,
        [(char)0x5F97] = 9,
        [(char)0x6025] = 10,
        [(char)0x6218] = 11,
        [(char)0x7D27] = 12,
        [(char)0x83B7] = 13,
        [(char)0x8FDB] = 14,
        [(char)0x9047] = 15,
        [(char)0x91D1] = 16,
    };
}
