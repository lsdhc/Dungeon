class StatusPanel : UIPanel
{
    public struct Status
    {
        public int HP;
        public int MaxHP;
        public int Gold;
        public int Attack;
        public int Defense;
        public int Seed;
        public int Floor;
        public int Speed;
    }

    private Status _status;

    public StatusPanel(ScreenObject parent, Status status)
        : base(parent, LayoutConfig.StatusPanelConfig)
    {
        _status = status;
    }

    public void UpdateStatus(Status status)
    {
        _status = status;
        Render();
    }

    public override void Render()
    {
        Surface.Clear();
        Surface.Print(1, 1, $"HP: {_status.HP}/{_status.MaxHP}");
        Surface.Print(1, 2, $"Gold: {_status.Gold}");
        Surface.Print(1, 3, $"Attack: {_status.Attack}");
        Surface.Print(1, 4, $"Defense: {_status.Defense}");
        Surface.Print(1, 5, $"Floor: {_status.Floor}");
        Surface.Print(1, 6, $"Speed: {_status.Speed}");
        RenderBorder();
    }
}
