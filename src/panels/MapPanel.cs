class MapPanel : UIPanel
{
    struct Map
    {
        public int Width;
        public int Height;
        public ColoredGlyph[,] Tiles;
    }

    private Map _map;
    public MapPanel(ScreenObject parent)
        : base(parent, LayoutConfig.MapPanel.X, LayoutConfig.MapPanel.Y,
               LayoutConfig.MapPanel.W, LayoutConfig.MapPanel.H)
    {
    }

    public override void Render()
    {
        Surface.Clear();
        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Surface.SetCellAppearance(x, y, _map.Tiles[x, y]);
            }
        }
        RenderBorder();
    }
    public void LoadMap(int width, int height, ColoredGlyph[,] tiles)
    {
        _map.Width = width;
        _map.Height = height;
        _map.Tiles = tiles;
    }
}