using System;

namespace AzureFunctionsMcp.Tools;

public static class McpToolDefinitions
{
    public static class GamesByCountryTool
    {
        public const string Name = "Games by Country";
        public const string Desc = "Get soccer games by Country.";

        public static class Param
        {
            public const string Name = "Country Name";
            public const string Desc = "Country name to get games for.";
        }
    }

    public static class AllGamesTool
    {
        public const string Name = "All Soccer Games";
        public const string Desc = "Get all historical soccer games.";
    }

    public static class GamesByCityTool
    {
        public const string Name = "Games by City";
        public const string Desc = "Get soccer games by City.";

        public static class Param
        {
            public const string Name = "City Name";
            public const string Desc = "City name to get games for.";
        }
    }

    public static class GamesWonTool
    {
        public const string Name = "Games Won by Country and Gender";
        public const string Desc = "Get the count of games won by a specific Country and Gender.";

        public static class ParamCountry
        {
            public const string Name = "Country";
            public const string Desc = "Country name to check games won for.";
        }

        public static class ParamSex
        {
            public const string Name = "Gender";
            public const string Desc = "Gender to check games won for (e.g., Men, Women).";
        }
    }

    public static class NextGamesTool
    {
        public const string Name = "Next Soccer Games";
        public const string Desc = "Get upcoming soccer games based on the current year.";
    }

    public static class GamesBySexTool
    {
        public const string Name = "Games by Gender Count";
        public const string Desc = "Get the total number of soccer games for a specific Gender.";

        public static class Param
        {
            public const string Name = "Gender";
            public const string Desc = "Gender to count games for (e.g., Men, Women).";
        }
    }

    public static class TypeDefinitions
    {
        public const string Number = "number";
        public const string String = "string";
    }
}
