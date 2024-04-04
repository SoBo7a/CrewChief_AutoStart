﻿public static class GameManager
{
    public static void Start()
    {
        (string crewChiefPath, List<GameInfo> games) = ConfigLoader.LoadConfigFromXml("config.xml");

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
                Console.WriteLine($"Game path specified for '{game.Name}' in the config file is invalid or not found.");
                UserInput.WaitForUserInput();
                return;
            }
        }

        // If only one game exists in config, start it automatically
        if (games.Count == 1)
        {
            GameLauncher.LaunchGame(games[0], crewChiefPath);
        }
        else
        {
            UserInput.SelectGameToLaunch(games, crewChiefPath);
        }

        // Start monitoring processes
        ProcessMonitor.MonitorProcesses(crewChiefPath);
    }

    public static void PrintSeparator()
    {
        Console.WriteLine("\n-----------------------------------------------\n");
    }
}