class MapSurfaceBuilder
{
    public static CellSurface BuildSurface(MapManager mapManager)
    {
        int H = mapManager.GetHeight();
        int W = mapManager.GetWidth();
        CellSurface Content = new(LayoutConfig.MapPanelConfig.W,LayoutConfig.MapPanelConfig.H);

        for(int i = 1;i < H;i++)
        {
            for(int t = 1;t < W;t++)
            {
                Style GlyphStyle = mapManager.GetTile(t,i).GetStyle();
                Content.SetCellAppearance(i,t,Style.GetColoredGlyphAndEffect(GlyphStyle));
            }
        }

        return Content;
    }
}