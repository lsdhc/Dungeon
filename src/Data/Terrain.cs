class Terrain
{
    private Style style;
    private bool accessible;
    public Terrain(Style style,bool Accessible)
    {
        this.style = style;
        this.accessible = Accessible;
    }

    public Style GetStyle()
    {
        return style;
    }

    public bool IsAccessible()
    {
        return accessible;
    }
}