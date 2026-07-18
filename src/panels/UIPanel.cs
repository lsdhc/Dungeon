abstract class UIPanel
{
    protected ScreenSurface Surface { get; }

    public UIPanel(ScreenObject parent, LayoutConfig.Panel config)
    {
        Surface = new ScreenSurface(config.W, config.H);
        Surface.Position = (config.X, config.Y);
        parent.Children.Add(Surface);
    }

    public abstract void Render();

    protected void RenderBorder()
    {
        var shape = ShapeParameters.CreateStyledBoxThin(Color.Gray);
        Surface.DrawBox(new Rectangle(0, 0, Surface.Width, Surface.Height), shape);
    }
}
