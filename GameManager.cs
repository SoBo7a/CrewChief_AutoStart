public static class GameManager
{
    public static void Start(string[] args)
    {
        (string crewChiefPath, List<GameInfo> games, List<AppInfo> apps) = ConfigLoader.LoadConfigFromXml("config.xml");

        // Check if CrewChief path exists
        if (string.IsNullOrEmpty(crewChiefPath) || !File.Exists(crewChiefPath))
        {
            Console.WriteLine("CrewChief path specified in the config file is invalid or not found.");
            UserInput.WaitForUserInput();
            return;
        }

        // Check if game paths exist
        foreach (var game in games)
        {
            if (!File.Exists(game.Path))
            {
                Console.WriteLine($"[ERROR] Game path specified for '{game.Name}' in the config file is invalid or not found.");
                UserInput.WaitForUserInput();
                return;
            }
        }

        // Check if app paths exist
        foreach (var app in apps)
        {
            if (!File.Exists(app.Path))
            {
                Console.WriteLine($"[ERROR] App path specified for '{app.Name}' in the config file is invalid or not found.");
                UserInput.WaitForUserInput();
                return;
            }
        }

        // If only one game exists in config, start it automatically
        if (games.Count == 1)
        {
            AppLauncher.LaunchApps(apps);
            GameLauncher.LaunchGame(games[0], crewChiefPath, apps);
        }
        else if (args.Length > 0)
        {
            if (args.Length < 2 || args[0] != "-game")
            {
                Console.WriteLine("[ERROR] Invalid arguments. Please provide a valid game name using the '-game' argument.");
                PrintSeparator();
                UserInput.SelectGameToLaunch(games, crewChiefPath, apps);
                return;
            }

            string gameName = args[1];
            string crewChiefArgs = CrewChiefArgumentResolver.GetCrewChiefArgs(gameName);

            if (!string.IsNullOrEmpty(crewChiefArgs))
            {
                GameInfo selectedGame = games.Find(g => g.Name.Equals(gameName, StringComparison.OrdinalIgnoreCase));
  
                if (selectedGame == null)
                {
                    Console.WriteLine($"[ERROR] No configuration found for: '{gameName}'.");
                    PrintSeparator();
                    UserInput.SelectGameToLaunch(games, crewChiefPath, apps);
                    return;
                }

                AppLauncher.LaunchApps(apps);
                GameLauncher.LaunchGame(selectedGame, crewChiefPath, apps);
            }
            else
            {
                Console.WriteLine($"[ERROR] Unsupported game specified in arguments: '{gameName}'.");
                PrintSeparator();
                UserInput.SelectGameToLaunch(games, crewChiefPath, apps);
            }
        }
        else
        {
            UserInput.SelectGameToLaunch(games, crewChiefPath, apps);
        }
    }

    public static void PrintSeparator()
    {
        Console.WriteLine("\n-----------------------------------------------\n");
    }
}
