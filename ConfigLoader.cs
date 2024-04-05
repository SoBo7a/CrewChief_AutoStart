using System;
using System.Collections.Generic;
using System.Xml;

public static class ConfigLoader
{
    public static (string, List<GameInfo>, List<AppInfo>) LoadConfigFromXml(string configFile)
    {
        string crewChiefPath = "";
        List<GameInfo> games = new List<GameInfo>();
        List<AppInfo> apps = new List<AppInfo>();

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

            // Read app configurations
            XmlNodeList appNodes = xmlDoc.SelectNodes("/config/apps/app");
            foreach (XmlNode appNode in appNodes)
            {
                string name = appNode.SelectSingleNode("name").InnerText;
                string path = appNode.SelectSingleNode("path").InnerText;
                bool autoClose = true; // AutoClose apps by default
                XmlNode autoCloseNode = appNode.SelectSingleNode("autoClose");
                if (autoCloseNode != null && bool.TryParse(autoCloseNode.InnerText, out bool autoCloseValue))
                {
                    autoClose = autoCloseValue;
                }
                apps.Add(new AppInfo { Name = name, Path = path, AutoClose = autoClose });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading config file: {ex.Message}");
        }

        return (crewChiefPath, games, apps);
    }
}
