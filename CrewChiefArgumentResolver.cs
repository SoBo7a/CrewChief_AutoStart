public static class CrewChiefArgumentResolver
{
    public static string GetCrewChiefArgs(string gameName)
    {
        switch (gameName)
        {
            case "RaceRoom":
                return "-game RACE_ROOM";
            case "PCARS2":
                return "-game PCARS2";
            case "PCARS_64BIT":
                return "-game PCARS_64BIT";
            case "PCARS_32BIT":
                return "-game PCARS_32BIT";
            case "PCARS_NETWORK":
                return "-game PCARS_NETWORK";
            case "PCARS2_NETWORK":
                return "-game PCARS2_NETWORK";
            case "RaceFactor1":
                return "-game RF1";
            case "AssettoCorsa_64BIT":
                return "-game ASSETTO_64BIT";
            case "AssettoCorsa_32BIT":
                return "-game ASSETTO_32BIT";
            case "RaceFactor2":
                return "-game RF2";
            case "RaceFactor2_64BIT":
                return "-game RF2_64BIT";
            case "iRacing":
                return "-game IRACING";
            case "F1_2018":
                return "-game F1_2018";
            case "F1_2019":
                return "-game F1_2019";
            case "AssettoCorsaCompetizione":
                return "-game ACC";
            case "Automobilista2":
                return "-game AMS2";
            case "Automobilista2_NETWORK":
                return "-game AMS2_NETWORK";
            case "Automobilista":
                return "-game AMS";
            case "FTRUCK":
                return "-game FTRUCK";
            case "MARCAS":
                return "-game MARCAS";
            case "GameStockCar":
                return "-game GSC";
            default:
                return "";
        }
    }
}
