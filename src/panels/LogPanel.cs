class LogPanel : UIPanel
{
    private ColoredString[] _logsToDisplay;

    private int _firstVisibleLineIndex;

    public LogPanel(ScreenObject parent)
        : base(parent, LayoutConfig.LogPanelConfig)
    {
        _logsToDisplay = new ColoredString[LayoutConfig.LogPanelConfig.INNER_H];
        _firstVisibleLineIndex = 0;
    }

    public void setLogBuffer(ColoredString[] logBuffer)
    {
        _logsToDisplay = logBuffer;
    }
    
    public override void Render()
    {
        Surface.Clear();
        int i = 1;
        foreach (var line in _logsToDisplay)
        {
            if(line == null)break;

            Surface.Print(1, i, line);
            i++;
        }
        RenderBorder();
    }

    /*
    这一段逻辑是处理log的，Panel仅用于显示log，log的逻辑应该在其他地方处理
    public void AddLog(ColoredString message)
    {
        _logBuffer[_firstVisibleLineIndex] = message;
        _firstVisibleLineIndex = (_firstVisibleLineIndex + 1) % BUFFER_SIZE;
        Render();
    }

    public void AddCommonLog(string message)
    {
        AddLog(ColoredString.Parser.Parse($"[*]: {message}"));
    }

    public void AddDangerLog(string message)
    {
        AddLog(ColoredString.Parser.Parse($"[c:r f:Red][!]: {message}"));
    }

    public void AddLuckyLog(string message)
    {
        AddLog(ColoredString.Parser.Parse($"[c:r f:Gold][+]: {message}"));
    }
    */
}
