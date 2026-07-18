class MapPanel(ScreenObject parent) : UIPanel(parent, LayoutConfig.MapPanelConfig)
{
    public struct Map
    {
        public int Width;
        public int Height;
        public ColoredGlyph[,] Tiles;
    }

    private Map _map;

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
    public void LoadMap(Map map)
    {
        _map = map;
    }
}