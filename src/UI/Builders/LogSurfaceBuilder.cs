static class LogSurfaceBuilder
{
    public static CellSurface BuildSurface(LogManager logManager)
    {
        CellSurface Content = new(LayoutConfig.LogPanelConfig.W, LayoutConfig.LogPanelConfig.H);
        int y = 1;
        foreach (Log log in logManager.GetLogs())
        {
            (string prefix, Color color) = log.Type switch
            {
                LogType.COMMON => ("[*]", Color.Gray),
                LogType.DANGER => ("[!]", Color.Red),
                LogType.LUCKY  => ("[+]", Color.Yellow),
                _              => ("[?]", Color.White)
            };

            WriteText(Content, 1, y, prefix + log.Message, color);
            y++;
        }
        return Content;
    }

    private static void WriteText(CellSurface surface, int x, int y, string text, Color color)
    {
        for (int i = 0; i < text.Length; i++)
        {
            int glyph = CharToGlyph.Map.TryGetValue(text[i], out int idx) ? idx : text[i];
            surface.SetGlyph(x + i, y, glyph);
            surface.SetForeground(x + i, y, color);
        }
    }
}