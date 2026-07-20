namespace Dungeon.Scenes;

class RootScreen : ScreenObject
{
    private readonly UIPanel _mapPanel;
    private readonly UIPanel _statusPanel;
    private readonly UIPanel _logPanel;
    private readonly UIPanel _controlsPanel;
    private readonly LogManager _logManager;
    private readonly MapManager _mapManager;
    public RootScreen()
    {
        _mapPanel      = new UIPanel(this, LayoutConfig.MapPanelConfig);
        _statusPanel   = new UIPanel(this, LayoutConfig.StatusPanelConfig);
        _logPanel      = new UIPanel(this, LayoutConfig.LogPanelConfig);
        _controlsPanel = new UIPanel(this, LayoutConfig.ControlsPanelConfig);

        _logManager = new LogManager();
        _mapManager = new MapManager();

        _logManager.AddCommunLog("test");
        _logManager.AddDangerLog("test");
        _logManager.AddLuckyLog("test");

        _logPanel.UpdateContent(LogSurfaceBuilder.BuildSurface(_logManager));
        _mapPanel.UpdateContent(MapSurfaceBuilder.BuildSurface(_mapManager));

        _mapPanel.Render();
        _statusPanel.Render();
        _logPanel.Render();
        _controlsPanel.Render();
    }
}
