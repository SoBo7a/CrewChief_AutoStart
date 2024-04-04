﻿using System.Diagnostics;

public static class GameLauncher
{
    public static void LaunchGame(GameInfo game, string crewChiefPath)
    {
        string crewChiefArgs = CrewChiefArgumentResolver.GetCrewChiefArgs(game.Name);

        Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Starting {game.Name}...");

        GameManager.PrintSeparator();

        StartProcess(game.Path);

        if (game.Name != "iRacing")
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] Starting CrewChief...");

            System.Threading.Thread.Sleep(10000); // Add startup delay for CrewChief 
            StartProcess(crewChiefPath, crewChiefArgs);
        }
    }

    public static void StartProcess(string fileName, string arguments = "")
    {
        Process process = new Process();
        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        // Set handlers to discard any console output
        process.OutputDataReceived += (sender, e) => { };
        process.ErrorDataReceived += (sender, e) => { };

        // Start the process
        process.Start();

        // Begin asynchronous reading of the output stream
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    }
}
