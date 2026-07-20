class Map
{
    private int Height;
    private int Width;
    private Tile[,] Tiles;

    public Map(int Height,int Width)
    {
        this.Height = Height;
        this.Width = Width;
        Tiles = new Tile[Height,Width];
        for (int y = 0; y < Height; y++)
    {
        for (int x = 0; x < Width; x++)
        {
            Tiles[y, x] = new Tile(Terrain.Wall);
        }
    }
    }
    public int GetHeight()
    {
        return Height;
    }

    public int GetWidth()
    {
        return Width;
    }

    public Tile GetTile(int x,int y)
    {
        return Tiles[x,y];
    }

    public void SetTile(int x,int y,Tile newTile)
    {
        Tiles[x,y] = newTile;
    }
}