class MapManager
{
    Map map;

    public MapManager()
    {
        map = new Map(10,10);
    }

    public Tile GetTile(int x,int y)
    {
        if(map == null)return new Tile(Terrain.Wall);
        else return map.GetTile(x,y);
    }

    public void SetMap(Map map)
    {
        this.map = map;
    }

    public int GetHeight()
    {
        return map.GetHeight();
    }

    public int GetWidth()
    {
        return map.GetWidth();
    }
}