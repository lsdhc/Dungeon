namespace Dungeon.Scenes;

class RootScreen : ScreenObject
{
    private readonly UIPanel _mapPanel;
    private readonly UIPanel _statusPanel;
    private readonly UIPanel _logPanel;
    private readonly UIPanel _controlsPanel;

    public RootScreen()
    {
        _mapPanel      = new UIPanel(this, LayoutConfig.MapPanelConfig);
        _statusPanel   = new UIPanel(this, LayoutConfig.StatusPanelConfig);
        _logPanel      = new UIPanel(this, LayoutConfig.LogPanelConfig);
        _controlsPanel = new UIPanel(this, LayoutConfig.ControlsPanelConfig);

        _mapPanel.Render();
        _statusPanel.Render();
        _logPanel.Render();
        _controlsPanel.Render();
    }
}
