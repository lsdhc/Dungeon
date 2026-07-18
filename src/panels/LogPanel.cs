class LogPanel : UIPanel
{
    private Queue<ColoredString> _logBuffer;

    private int _firstVisibleLineIndex;

    public LogPanel(ScreenObject parent)
        : base(parent, LayoutConfig.LogPanel.X, LayoutConfig.LogPanel.Y,
               LayoutConfig.LogPanel.W, LayoutConfig.LogPanel.H)
    {
        _logBuffer = new Queue<ColoredString>();
        _firstVisibleLineIndex = 0;
    }

    public override void Render()
    {
        Surface.Clear();
        int i = 1;
        foreach (var log in _logBuffer.Skip(_firstVisibleLineIndex).Take(LayoutConfig.LogPanel.MAX_LOG_LINES))
        {
            Surface.Print(1, i, log);
            i++;
        }
        RenderBorder();
    }

    public void AddLog(ColoredString message)
    {
        _logBuffer.Enqueue(message);
        if (_logBuffer.Count > LayoutConfig.LogPanel.BUFFER_SIZE)
            _logBuffer.Dequeue();
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
}
