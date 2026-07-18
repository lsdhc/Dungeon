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


        var testMap = CreateTestMap();
        _mapPanel.LoadMap(testMap.GetLength(0), testMap.GetLength(1), testMap);
        _mapPanel.Render();

        _logPanel.AddCommonLog("Game started.");
        _statusPanel.Render();
        _controlsPanel = new ControlsPanel(this);
        _controlsPanel.Render();
    }

    private static ColoredGlyph[,] CreateTestMap()
    {
        int w = LayoutConfig.MapPanel.INNER_W;
        int h = LayoutConfig.MapPanel.INNER_H;
        var tiles = new ColoredGlyph[w, h];

        var wall  = new ColoredGlyph(Color.Gray,       Color.Black, '#');
        var floor = new ColoredGlyph(Color.DarkGray,   Color.Black, '.');
        var player = new ColoredGlyph(Color.Green,     Color.Black, '@');
        var stairs = new ColoredGlyph(Color.Purple,    Color.Black, '>');
        var enemy  = new ColoredGlyph(Color.Red,       Color.Black, 'E');
        var water  = new ColoredGlyph(Color.Blue,      Color.Black, '~');

        for (int y = 0; y < h; y++)
        for (int x = 0; x < w; x++)
        {
            // 边界墙
            if (x == 0 || y == 0 || x == w - 1 || y == h - 1)
                tiles[x, y] = wall;
            else
                tiles[x, y] = floor;
        }

        // 房间墙壁
        for (int x = 10; x <= 20; x++) { tiles[x, 5] = wall; tiles[x, 10] = wall; }
        for (int y = 5; y <= 10; y++) { tiles[10, y] = wall; tiles[20, y] = wall; }
        tiles[10, 5] = floor; tiles[20, 5] = floor;  // 门

        // 走廊
        for (int x = 20; x <= 35; x++) tiles[x, 7] = floor;
        for (int x = 35; x <= 40; x++) { tiles[x, 6] = wall; tiles[x, 8] = wall; }

        // 障碍物
        tiles[25, 12] = wall; tiles[26, 12] = wall; tiles[27, 12] = wall;
        tiles[30, 15] = wall; tiles[31, 15] = wall;
        tiles[15, 18] = wall;
        tiles[40, 10] = wall; tiles[40, 11] = wall;

        // 水域
        for (int x = 35; x <= 38; x++)
        for (int y = 5; y <= 6; y++)
            tiles[x, y] = water;

        // 玩家起点
        tiles[5, 5] = player;

        // 敌人
        tiles[15, 8] = enemy;
        tiles[28, 7] = enemy;
        tiles[42, 18] = enemy;

        // 楼梯
        tiles[45, 18] = stairs;

        return tiles;
    }

    public override bool ProcessKeyboard(SadConsole.Input.Keyboard info)
    {
        if (!info.HasKeysPressed) return false;

        foreach (var asciiKey in info.KeysPressed)
        {
            switch (asciiKey.Key)
            {
                case SadConsole.Input.Keys.D1:
                    _logPanel.AddDangerLog("You hit a slime!    -5 HP");
                    break;
                case SadConsole.Input.Keys.D2:
                    _logPanel.AddLuckyLog("Found a health potion! +20 HP");
                    break;
                case SadConsole.Input.Keys.D3:
                    _logPanel.AddCommonLog("Stairs ahead...");
                    break;
                case SadConsole.Input.Keys.D4:
                    _logPanel.AddDangerLog("Path blocked by rock");
                    break;
            }
        }
        return true;
    }
}
