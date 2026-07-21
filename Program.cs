using SadConsole.Configuration;

Settings.WindowTitle = "Dungeon";
Settings.AllowWindowResize = false;

Builder
    .GetBuilder()
    .SetWindowSizeInCells(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<Dungeon.Scenes.RootScreen>()
    .IsStartingScreenFocused(true)
    .ConfigureFonts("src/Core/Font/GameFont.font")
    .Run();
