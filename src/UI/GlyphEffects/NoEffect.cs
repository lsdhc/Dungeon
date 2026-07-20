class NoEffect : GlyphEffect
{
    public override ColoredGlyphAndEffect SetEffect(ColoredGlyphAndEffect Glyph)
    {
        Glyph.Effect = null;
        return Glyph;
    }
}