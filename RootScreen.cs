namespace Dungeon.Scenes;

class RootScreen : ScreenObject
{
    private LogPanel _logPanel;
    private StatusPanel _statusPanel;
    private MapPanel _mapPanel;
    private ControlsPanel _controlsPanel;

    public RootScreen()
    {
        _logPanel = new LogPanel(this);
        _statusPanel = new StatusPanel(this, new StatusPanel.Status
        {
            HP = 100,
            MaxHP = 100,
            Gold = 0,
            Attack = 10,
            Defense = 5,
            Seed = 12345,
            Floor = 1,
            Speed = 1
        });
        _mapPanel = new MapPanel(this);

        _logPanel.setLogBuffer(new ColoredString[]
        {
            ColoredString.Parser.Parse("[c:r f:Gold][+] Welcome to LZ's Dungeon!"),
            ColoredString.Parser.Parse("[*]: Game started."),
            ColoredString.Parser.Parse("[c:r f:Red][!] A slime approaches!"),
        });
        _logPanel.Render();

        var w = LayoutConfig.MapPanelConfig.INNER_W;
        var h = LayoutConfig.MapPanelConfig.INNER_H;
        var tiles = new ColoredGlyph[w, h];
        var wall  = new ColoredGlyph(Color.Gray,     Color.Black, '#');
        var floor = new ColoredGlyph(Color.DarkGray, Color.Black, '.');
        var player = new ColoredGlyph(Color.Green,   Color.Black, '@');
        var stairs = new ColoredGlyph(Color.Purple,  Color.Black, '>');
        var enemy  = new ColoredGlyph(Color.Red,     Color.Black, 'E');

        for (int y = 0; y < h; y++)
        for (int x = 0; x < w; x++)
            tiles[x, y] = (x == 0 || y == 0 || x == w - 1 || y == h - 1) ? wall : floor;

        tiles[15, 5] = wall; tiles[16, 5] = wall; tiles[17, 5] = wall;
        tiles[5, 5] = player;
        tiles[40, 18] = enemy;
        tiles[45, 18] = stairs;

        _mapPanel.LoadMap(new MapPanel.Map { Width = w, Height = h, Tiles = tiles });
        _mapPanel.Render();

        _statusPanel.Render();
        _controlsPanel = new ControlsPanel(this);
        _controlsPanel.Render();
    }

    public override bool ProcessKeyboard(SadConsole.Input.Keyboard info)
    {
        if (!info.HasKeysPressed) return false;

        
        return true;
    }
}
