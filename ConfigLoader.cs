using System.Xml;

public static class ConfigLoader
{
    public static (string, List<GameInfo>) LoadConfigFromXml(string configFile)
    {
        string crewChiefPath = "";
        List<GameInfo> games = new List<GameInfo>();

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);

            // Read CrewChief path
            XmlNode crewChiefNode = xmlDoc.SelectSingleNode("/config/crewChiefPath");
            if (crewChiefNode != null)
            {
                crewChiefPath = crewChiefNode.InnerText;
            }

            // Read game configurations
            XmlNodeList gameNodes = xmlDoc.SelectNodes("/config/games/game");
            foreach (XmlNode gameNode in gameNodes)
            {
                string name = gameNode.SelectSingleNode("name").InnerText;
                string path = gameNode.SelectSingleNode("path").InnerText;
                games.Add(new GameInfo { Name = name, Path = path });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading config file: {ex.Message}");
        }

        return (crewChiefPath, games);
    }
}
