class Style
{
    private readonly GameColor.RGB FColor;
    private readonly GameColor.RGB BColor;
    private readonly Char sign;
    private readonly GlyphEffect glyphEffect;

    public Style(GameColor.RGB ForeColor,GameColor.RGB BackColor,Char sign,GlyphEffect glyphEffect)
    {
        FColor = ForeColor;
        BColor = BackColor;
        this.sign = sign;
        this.glyphEffect = glyphEffect;
    }
    static public ColoredGlyphAndEffect GetColoredGlyphAndEffect(Style style)
    {

        return style.glyphEffect.SetEffect(ColoredGlyphAndEffect.FromColoredGlyph(style.GetColoredGlyph()));
    }

    private ColoredGlyph GetColoredGlyph()
    {
        SadRogue.Primitives.Color F = new(FColor.R,FColor.G,FColor.B);
        SadRogue.Primitives.Color B = new(BColor.R,BColor.G,BColor.B);
        return new ColoredGlyph(F,B,sign);
    }
}