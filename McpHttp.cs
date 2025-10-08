using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

using AzureFunctionsMcp.Services;

namespace MCP.HttpTrigger;

public class McpHttp
{
    private readonly ILogger<McpHttp> _logger;

    public McpHttp(ILogger<McpHttp> logger)
    {
        _logger = logger;
    }

    [Function("McpHttp")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }

    [Function("Test")]
    public IActionResult Test(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest req
    )
    {
        _logger.LogInformation("Erm, that the sigma?");
        return new OkObjectResult("This is an okay response from the goat.");
    }

    [Function("SoccerGamesTest")]
    public IActionResult TestSoccerGames(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest req
    )
    {
        _logger.LogInformation("We are gaming gentlemen");
        _logger.LogInformation(SoccerGamesServices.GetSoccerGames().GetAwaiter().GetResult()[0].ToString());

        return new OkObjectResult("Bro everything is A-OK");
    }
}
