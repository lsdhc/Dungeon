static class LayoutConfig
{
    public struct MapPanel
    {
        public const int X = 1;
        public const int Y = 0;
        public const int W = 53;    // 含边框, 内容区 50
        public const int H = 24;    // 含边框, 内容区 22
        public const int INNER_W = W - 2;
        public const int INNER_H = H - 2;
    }
    
    public struct MessagePanel
    {
        public const int X = 1;
        public const int Y = 25;
        public const int W = 52;    // 含边框, 内容区 50
        public const int H = 4;     // 含边框, 内容区 2
        public const int INNER_W = W - 2;
        public const int INNER_H = H - 2;
    }

    public struct StatusPanel
    {
        public const int X = 55;
        public const int Y = 0;
        public const int W = 34;    // 含边框, 内容区 32
        public const int H = 8;     // 含边框, 内容区 5
        public const int INNER_W = W - 2;
        public const int INNER_H = H - 2;
    }
    
    public struct ControlsPanel
    {
        public const int X = 1;
        public const int Y = 24;
        public const int W = 88;    // 含边框, 内容区 86
        public const int H = 6;     // 含边框, 内容区 3
        public const int INNER_W = W - 2;
        public const int INNER_H = H - 2;
    }

    public struct LogPanel
    {
        public const int X = 55;
        public const int Y = 8;
        public const int W = 34;    // 含边框, 内容区 32
        public const int H = 16;    // 含边框, 内容区 14
        public const int INNER_W = W - 2;
        public const int INNER_H = H - 2;

        public const int BUFFER_SIZE = 30;    // 日志缓冲区大小
        public const int MAX_LOG_LINES = INNER_H;  // 最大日志行数
    }

    public struct Screen
    {
        public const int W = 90;
        public const int H = 30;
    }
}
