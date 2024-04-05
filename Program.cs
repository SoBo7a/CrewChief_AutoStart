using System;

class Program
{
    static void Main()
    {
        string version = "0.1.3-beta";

        Console.Title = $"CrewChief_AutoStart - v{version}";

        GameManager.Start();
    }
}
