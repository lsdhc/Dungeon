class UIPanel
{
    private LayoutConfig.Panel Config { get; }
    private ScreenSurface Surface { get; }

    public UIPanel(ScreenObject parent, LayoutConfig.Panel config)
    {
        Config = config;
        Surface = new ScreenSurface(config.W, config.H)
        {
            Position = (config.X, config.Y)
        };
        parent.Children.Add(Surface);
    }

    public void UpdateContent(CellSurface content)
    {
        Surface.Surface = content;
    }
    public void Render()
    {
        RenderBorder();
    }

    private void RenderBorder()
    {
        int h = CharToGlyph.Map.TryGetValue('-', out int ih) ? ih : '-';
        int v = CharToGlyph.Map.TryGetValue('|', out int iv) ? iv : '|';
        int c = CharToGlyph.Map.TryGetValue('+', out int ic) ? ic : '+';

        for (int x = 1; x < Surface.Width - 1; x++)
        {
            Surface.SetGlyph(x, 0, h); Surface.SetForeground(x, 0, Color.Gray);
            Surface.SetGlyph(x, Surface.Height - 1, h); Surface.SetForeground(x, Surface.Height - 1, Color.Gray);
        }
        for (int y = 1; y < Surface.Height - 1; y++)
        {
            Surface.SetGlyph(0, y, v); Surface.SetForeground(0, y, Color.Gray);
            Surface.SetGlyph(Surface.Width - 1, y, v); Surface.SetForeground(Surface.Width - 1, y, Color.Gray);
        }

        Surface.SetGlyph(0, 0, c); Surface.SetForeground(0, 0, Color.Gray);
        Surface.SetGlyph(Surface.Width - 1, 0, c); Surface.SetForeground(Surface.Width - 1, 0, Color.Gray);
        Surface.SetGlyph(0, Surface.Height - 1, c); Surface.SetForeground(0, Surface.Height - 1, Color.Gray);
        Surface.SetGlyph(Surface.Width - 1, Surface.Height - 1, c); Surface.SetForeground(Surface.Width - 1, Surface.Height - 1, Color.Gray);
    }
}
