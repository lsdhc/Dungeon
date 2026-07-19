using System.Net.Mime;

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
        var shape = ShapeParameters.CreateStyledBoxThick(Color.Gray);
        Surface.DrawBox(new Rectangle(0, 0, Surface.Width, Surface.Height), shape);
    }
}
