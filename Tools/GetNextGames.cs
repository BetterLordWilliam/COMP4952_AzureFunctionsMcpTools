using AzureFunctionsMcp.Services;
using AzureFunctionsMcp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

public class NextGames
{
    private readonly ILogger<NextGames> _logger;

    public NextGames(ILogger<NextGames> logger)
    {
        _logger = logger;
    }

    [Function("GetNextSoccerGames")]
    public IActionResult Run(
        [McpToolTrigger(McpToolDefinitions.NextGamesTool.Name,
                        McpToolDefinitions.NextGamesTool.Desc)]
        ToolInvocationContext context
    )
    {
        _logger.LogInformation("Getting games in the future.");

        List<SoccerGame> games = SoccerGamesServices
            .GetNextGames()
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}
