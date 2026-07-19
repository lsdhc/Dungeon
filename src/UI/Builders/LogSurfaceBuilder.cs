static class LogSurfaceBuilder
{
    public static CellSurface BuildSurface(LogManager logManager)
    {
        CellSurface Content = new(LayoutConfig.LogPanelConfig.W,LayoutConfig.LogPanelConfig.H);
        int y = 1;
        foreach(Log log in logManager.GetLogs())
        {
            ColoredString NextLog = log.Type switch
            {
                LogType.COMMON => ColoredString.Parser.Parse(GameColor.Str.Gray + "[*]" + log.Message),
                LogType.DANGER => ColoredString.Parser.Parse(GameColor.Str.Red + "[!]" + log.Message),
                LogType.LUCKY => ColoredString.Parser.Parse(GameColor.Str.Yelle + "[+]" + log.Message),
                _ => ColoredString.Parser.Parse("[c:r f:White][未出现类型]" + log.Message)
            };
            Content.Print(1,y,NextLog);
            y++;
        }
        return Content;
    }
}