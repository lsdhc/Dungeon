class ControlsPanel : UIPanel
{
    
    public ControlsPanel(ScreenObject parent)
        : base(parent, LayoutConfig.ControlsPanelConfig)
    {
    }

    public override void Render()
    {
        Surface.Clear();
        RenderBorder();
    }
}