using AzureFunctionsMcp.Services;
using AzureFunctionsMcp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Mcp;
using Microsoft.Extensions.Logging;

public class GamesBySex
{
    private readonly ILogger<GamesBySex> _logger;

    public GamesBySex(ILogger<GamesBySex> logger)
    {
        _logger = logger;
    }

    [Function("GetNumberOfGamesByGender")]
    public IActionResult Run(
        [McpToolTrigger(McpToolDefinitions.GamesBySexTool.Name,
                        McpToolDefinitions.GamesBySexTool.Desc)]
        ToolInvocationContext context,
        [McpToolProperty(McpToolDefinitions.GamesBySexTool.Param.Name,
                         McpToolDefinitions.TypeDefinitions.String,
                         McpToolDefinitions.GamesBySexTool.Param.Desc)]
        string sex
    )
    {
        _logger.LogInformation($"Getting total games for gender: {sex}");

        int games = SoccerGamesServices
            .GetNumGamesForSex(sex)
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(games);
    }
}
