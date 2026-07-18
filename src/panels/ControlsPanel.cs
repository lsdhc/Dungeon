class ControlsPanel : UIPanel
{
    
    public ControlsPanel(ScreenObject parent)
        : base(parent, LayoutConfig.ControlsPanel.X, LayoutConfig.ControlsPanel.Y,
               LayoutConfig.ControlsPanel.W, LayoutConfig.ControlsPanel.H)
    {
    }

    public override void Render()
    {
        Surface.Clear();
        RenderBorder();
    }
}