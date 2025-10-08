using AzureFunctionsMcp.Services;
using AzureFunctionsMcp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

public class GamesByCity
{
    private readonly ILogger<GamesByCity> _logger;

    public GamesByCity(ILogger<GamesByCity> logger)
    {
        _logger = logger;
    }

    [Function("GetSoccerGamesByCity")]
    public IActionResult Run(
        [McpToolTrigger(McpToolDefinitions.GamesByCityTool.Name,
                        McpToolDefinitions.GamesByCityTool.Desc)]
        ToolInvocationContext context,
        [McpToolProperty(McpToolDefinitions.GamesByCityTool.Param.Name,
                         McpToolDefinitions.TypeDefinitions.String,
                         McpToolDefinitions.GamesByCityTool.Param.Desc)]
        string city
    )
    {
        _logger.LogInformation($"Getting games for city: {city}");

        List<SoccerGame> games = SoccerGamesServices
            .GetSoccerGamesForCity(city)
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}