using AzureFunctionsMcp.Services;
using AzureFunctionsMcp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

public class AllGames
{
    private readonly ILogger<AllGames> _logger;

    public AllGames(ILogger<AllGames> logger)
    {
        _logger = logger;
    }

    [Function("GetAllSoccerGames")]
    public IActionResult Run(
        [McpToolTrigger(McpToolDefinitions.AllGamesTool.Name,
                        McpToolDefinitions.AllGamesTool.Desc)]
        ToolInvocationContext context
    )
    {
        List<SoccerGame> games = SoccerGamesServices
            .GetSoccerGames()
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}
