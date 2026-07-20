class Terrain(Style style, bool Accessible)
{
    private readonly Style style = style;
    private readonly bool accessible = Accessible;

    public Style GetStyle()
    {
        return style;
    }

    public bool IsAccessible()
    {
        return accessible;
    }

    static private Style WallStyle = new(GameColor.Gray,'#');
    static public Terrain Wall = new(WallStyle,false);

    static private Style RoadStyle = new(GameColor.Gray,' ');
    static public Terrain Road = new(RoadStyle,true);
}