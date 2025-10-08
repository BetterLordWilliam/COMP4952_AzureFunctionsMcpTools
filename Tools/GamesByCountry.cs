using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

using AzureFunctionsMcp.Services;

namespace AzureFunctionsMcp.Tools;

public class GamesByCountry
{
    private readonly ILogger<GamesByCountry> _logger;

    public GamesByCountry(ILogger<GamesByCountry> logger)
    {
        _logger = logger;
    }

    [Function("GetSoccerGamesByCountry")]
    public IActionResult Run(
        [McpToolTrigger(    McpToolDefinitions.GamesByCountryTool.Name,
                            McpToolDefinitions.GamesByCountryTool.Desc)]
        ToolInvocationContext context,
        [McpToolProperty(   McpToolDefinitions.GamesByCountryTool.Param.Name,
                            McpToolDefinitions.TypeDefinitions.String,
                            McpToolDefinitions.GamesByCountryTool.Param.Desc)]
        string country
    )
    {
        _logger.LogInformation($"Getting games for country: {country}");

        List<SoccerGame> games = SoccerGamesServices
            .GetSoccerGamesForCountry(country)
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}
