using AzureFunctionsMcp.Services;
using AzureFunctionsMcp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

public class GamesWon
{
    private readonly ILogger<GamesWon> _logger;

    public GamesWon(ILogger<GamesWon> logger)
    {
        _logger = logger;
    }

    [Function("GetGamesWonForCountryAndGender")]
    public IActionResult Run(
        [McpToolTrigger(McpToolDefinitions.GamesWonTool.Name,
                        McpToolDefinitions.GamesWonTool.Desc)]
        ToolInvocationContext context,
        [McpToolProperty(McpToolDefinitions.GamesWonTool.ParamCountry.Name,
                         McpToolDefinitions.TypeDefinitions.String,
                         McpToolDefinitions.GamesWonTool.ParamCountry.Desc)]
        string country,
        [McpToolProperty(McpToolDefinitions.GamesWonTool.ParamSex.Name,
                         McpToolDefinitions.TypeDefinitions.String,
                         McpToolDefinitions.GamesWonTool.ParamSex.Desc)]
        string sex
    )
    {
        _logger.LogInformation($"Getting games won for country: {country}, and sex: {sex}.");

        int games = SoccerGamesServices
            .GetGamesWonForCountrySex(country, sex)
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}
