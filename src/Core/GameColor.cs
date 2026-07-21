public static class GameColor
{
    public static class Str
    {
        public const string Red = "[c:r f:180,60,60]";
        public const string Yellow = "[c:r f:200,180,70]";
        public const string Gray = "[c:r f:128,128,128]";
    }

    public readonly record struct RGB
    (
        int R,
        int G,
        int B
    );
    public static RGB Red = new(180,60,60);
    public static RGB Gray = new(128,128,128);
    public static RGB Yellow = new(200,180,70);
}
    