public static class UserInput
{
    public static void SelectGameToLaunch(List<GameInfo> games, string crewChiefPath, List<AppInfo> apps)
    {
        Console.WriteLine("Select a sim to launch: \n");
        for (int i = 0; i < games.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {games[i].Name}");
        }

        GameManager.PrintSeparator();

        int choice;
        while (!int.TryParse(ReadKey().KeyChar.ToString(), out choice) || choice < 1 || choice > games.Count)
        {
            Console.WriteLine("\nInvalid input. Please enter a number corresponding to the sim you want to launch:");
        }

        if (apps.Count > 0)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Starting Apps...");
            GameManager.PrintSeparator();
            AppLauncher.LaunchApps(apps);
        }
        GameLauncher.LaunchGame(games[choice - 1], crewChiefPath);
    }

    public static ConsoleKeyInfo ReadKey()
    {
        var key = Console.ReadKey(intercept: true);
        Console.Write("\b \b"); // Clear the character entered by user from the console
        return key;
    }

    public static void WaitForUserInput()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
