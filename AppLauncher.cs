using System.Diagnostics;

public static class AppLauncher
{
    public static void LaunchApps(List<AppInfo> apps)
    {
        foreach (var app in apps)
        {
            try
            {
                Process.Start(app.Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start {app.Name}: {ex.Message}");
                GameManager.PrintSeparator();
            }
        }
    }
}
