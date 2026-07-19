static class LogSurfaceBuilder
{
    public static CellSurface BuildSurface(LogManager logManager)
    {
        CellSurface Content = new(LayoutConfig.LogPanelConfig.W,LayoutConfig.LogPanelConfig.H);
        int y = 1;
        foreach(LogManager.Log log in logManager.GetLogs())
        {
            ColoredString NextLog = log.Type switch
            {
                LogManager.LogType.COMMUN => ColoredString.Parser.Parse(StringTypeCode.Gray + "[*]" + log.Message),
                LogManager.LogType.DANGER => ColoredString.Parser.Parse(StringTypeCode.Red + "[!]" + log.Message),
                LogManager.LogType.LUCKY => ColoredString.Parser.Parse(StringTypeCode.Yello + "[+]" + log.Message),
                _ => ColoredString.Parser.Parse("[c:r f:White][未出现类型]" + log.Message)
            };
            Content.Print(1,y,NextLog);
            y++;
        }
        return Content;
    }
}