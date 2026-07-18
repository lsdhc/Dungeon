using SadConsole.Configuration;

Settings.WindowTitle = "My SadConsole Game";
Settings.AllowWindowResize = false;

Builder
    .GetBuilder()
    .SetWindowSizeInCells(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<Dungeon.Scenes.RootScreen>()
    .IsStartingScreenFocused(true)
    .ConfigureFonts(true)
    .Run();
    