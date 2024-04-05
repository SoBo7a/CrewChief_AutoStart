using System.Diagnostics;

public static class ProcessMonitor
{
    private static bool IsIRacingRunning()
    {
        Process[] processes = Process.GetProcessesByName("iRacingSim64DX11");
        return processes.Length > 0;
    }

    private static bool IsIRacingUIRunning()
    {
        Process[] processes = Process.GetProcessesByName("iracingui");
        return processes.Length > 0;
    }

    private static bool IsCrewChiefRunning()
    {
        Process[] processes = Process.GetProcessesByName("CrewChiefV4");
        return processes.Length > 0;
    }

    private static bool IsGameRunning(GameInfo game)
    {
        string exeName = Path.GetFileNameWithoutExtension(game.Path);
        Process[] processes = Process.GetProcessesByName(exeName);
        return processes.Length > 0;
    }

    private static bool IsAppRunning(AppInfo app)
    {
        string exeName = Path.GetFileNameWithoutExtension(app.Path);
        Process[] processes = Process.GetProcessesByName(exeName);
        return processes.Length > 0;
    }

    public static void MonitorProcesses(string crewChiefPath, GameInfo game, List<AppInfo> apps)
    {
        bool iracingSessionInProgress = false;

        // Specific handling in case iracingui.exe is used, in order to start crewchief only on active sessions and stop afterwards
        while (IsIRacingUIRunning())
        {
            if (!iracingSessionInProgress)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Waiting for iRacing Session...");
                GameManager.PrintSeparator();
                iracingSessionInProgress = true;
            }

            if (IsIRacingRunning() && !IsCrewChiefRunning())
            {
                // Start CrewChief for iRacing
                Thread.Sleep(25000); // Give iRacing some time to load up before starting CC
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Starting CrewChief for iRacing...");
                GameManager.PrintSeparator();
                string crewChiefArgs = CrewChiefArgumentResolver.GetCrewChiefArgs("iRacing");
                GameLauncher.StartProcess(crewChiefPath, crewChiefArgs);

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Waiting for iRacing Session to end...");
                GameManager.PrintSeparator();
            }
            else if (!IsIRacingRunning() && IsCrewChiefRunning())
            {
                // iRacing session closed, so close CrewChief if running
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Closing CrewChief for iRacing...");
                GameManager.PrintSeparator();
                Process[] processes = Process.GetProcessesByName("CrewChiefV4");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
                iracingSessionInProgress = false; // Reset iRacing session flag
            }

            Thread.Sleep(500); // Check every 500 milliseconds
        }

        // Monitor the selected game
        while (IsGameRunning(game) || IsCrewChiefRunning())
        {
            if (!IsGameRunning(game) && IsCrewChiefRunning())
            {
                // Game session closed, so close CrewChief if running
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Closing CrewChief for {game.Name}...");
                GameManager.PrintSeparator();
                Process[] processes = Process.GetProcessesByName("CrewChiefV4");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }

            Thread.Sleep(500); // Check every 500 milliseconds
        }

        // Check and close associated apps
        foreach (var app in apps)
        {
            if (app.AutoClose && !IsGameRunning(game) && IsAppRunning(app))
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Closing {app.Name}...");
                GameManager.PrintSeparator();
                Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(app.Path));
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}
