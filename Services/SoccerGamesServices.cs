using System.Net.Http.Json;
using System.Text.Json;

namespace AzureFunctionsMcp.Services;

public class SoccerGame
{
    public int GameId { get; set; }
    public int Year { get; set; }
    public required string Gender { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string Continent { get; set; }
    public required string Winner { get; set; }

    public override string ToString()
    {
        return $"{{ GameId: \"{GameId}\", "
            + $"Year: \"{Year}\", Gender: \"{Gender}\", "
            + $"City: \"{City}\", Country: \"{Country}\", "
            + $"Continent: \"{Continent}\", Winner: \"{Winner}\" }}";
    }
}

public static class SoccerGamesServices
{
    static readonly string Endpoint = "https://gist.githubusercontent.com/medhatelmasry/bc40ebfa5ed41b7512e36e6bfbcd18bd/raw/f24b734bb012061e97fead5980c34ffa0d73587e/fifa-world-cup.json";
    static readonly HttpClient client = new HttpClient();

    public static async Task<List<SoccerGame>> GetSoccerGames()
    {
        List<SoccerGame>? res;

        res = await client.GetFromJsonAsync<List<SoccerGame>>(Endpoint);

        return res!;
    }

    public static async Task<List<SoccerGame>> GetSoccerGamesForCountry(string country)
    {
        List<SoccerGame> games = await GetSoccerGames();
        List<SoccerGame> gamesForCountry = games.Where(o => o.Country.Equals(country)).ToList();

        return gamesForCountry;
    }

    public static async Task<List<SoccerGame>> GetSoccerGamesForCity(string city)
    {
        List<SoccerGame> games = await GetSoccerGames();
        List<SoccerGame> gamesForCity = games.Where(o => o.City.Equals(city)).ToList();

        return gamesForCity;
    }

    public static async Task<int> GetGamesWonForCountrySex(string country, string sex)
    {
        List<SoccerGame> games = await GetSoccerGames();
        int gamesWonForCountryBySex = games
            .Where(o => o.Winner.Equals(country))
            .Where(o => o.Gender.Equals(sex))
            .Count();

        return gamesWonForCountryBySex;
    }

    public static async Task<List<SoccerGame>> GetNextGames()
    {
        int year = new DateTime().Year;     // Get the current year
        List<SoccerGame> games = await GetSoccerGames();
        List<SoccerGame> gamesInTheFuture = games.Where(o => o.Year > year).ToList();

        return gamesInTheFuture;
    }

    public static async Task<int> GetNumGamesForSex(string sex)
    {
        List<SoccerGame> games = await GetSoccerGames();
        int gamesForSex = games.Where(o => o.Gender.Equals(sex)).Count();

        return gamesForSex;
    }
}
