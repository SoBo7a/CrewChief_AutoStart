class Program
{
    static void Main(string[] args)
    {
        string version = "0.1.3-beta";

        Console.Title = $"CrewChief_AutoStart - v{version}";

        GameManager.Start(args);
    }
}
