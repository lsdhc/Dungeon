class Tile
{
    private Terrain terrain;

    public Tile(Terrain terrain)
    {
        this.terrain = terrain;
    }
    public Style GetStyle()
    {
        return terrain.GetStyle();
    }
}