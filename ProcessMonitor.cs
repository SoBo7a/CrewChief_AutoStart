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

    public static void MonitorProcesses(string crewChiefPath)
    {
        bool sessionInProgress = false;

        while (IsIRacingUIRunning())
        {
            if (!sessionInProgress)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Waiting for Session...");
                GameManager.PrintSeparator();
                sessionInProgress = true;
            }

            if (IsIRacingRunning() && !IsCrewChiefRunning())
            {
                // Start CrewChief
                Thread.Sleep(25000); // Give iRacing some time to load up before starting CC
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Starting CrewChief...");
                GameManager.PrintSeparator();
                string crewChiefArgs = CrewChiefArgumentResolver.GetCrewChiefArgs("iRacing");
                GameLauncher.StartProcess(crewChiefPath, crewChiefArgs);

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Waiting for Session to end...");
                GameManager.PrintSeparator();
            }
            else if (!IsIRacingRunning() && IsCrewChiefRunning())
            {
                // iRacing closed, so close CrewChief if running
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Closing CrewChief...");
                GameManager.PrintSeparator();
                Process[] processes = Process.GetProcessesByName("CrewChiefV4");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
                sessionInProgress = false; // Reset session flag
            }

            Thread.Sleep(5000); // Check every 5 seconds
        }
    }
}
