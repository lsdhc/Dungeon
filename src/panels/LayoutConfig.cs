class LayoutConfig
{
    public struct Panel
    {
        public int X;
        public int Y;
        public int W;
        public int H;
        public int INNER_W;
        public int INNER_H;

        public Panel(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            INNER_W = W - 2;
            INNER_H = H - 2;
        }
    }


    public static readonly Panel MapPanelConfig = new(1, 0, 53, 24);
    
    public static readonly Panel StatusPanelConfig = new(55, 0, 34, 8);

    public static readonly Panel ControlsPanelConfig = new(1, 24, 88, 6);

    public static readonly Panel LogPanelConfig = new(55, 8, 34, 16);
    public struct Screen
    {
        public const int W = 90;
        public const int H = 30;
    }
}
