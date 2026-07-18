abstract class UIPanel
{
    protected ScreenSurface Surface { get; }

    public UIPanel(ScreenObject parent, int x, int y, int w, int h)
    {
        Surface = new ScreenSurface(w, h);
        Surface.Position = (x, y);
        parent.Children.Add(Surface);
    }

    public abstract void Render();

    protected void RenderBorder()
    {
        var shape = ShapeParameters.CreateStyledBoxThin(Color.Gray);
        Surface.DrawBox(new Rectangle(0, 0, Surface.Width, Surface.Height), shape);
    }
}
