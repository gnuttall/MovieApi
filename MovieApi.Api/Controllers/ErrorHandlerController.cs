using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Services.Models;

namespace MovieApi.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorHandlerController : Controller
{
    private readonly ILogger<ErrorHandlerController> _logger;

    public ErrorHandlerController(ILogger<ErrorHandlerController> logger)
    {
        _logger = logger;
    }
    
    [Route("/error")]
    public Attempt Error()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var useDetailedErrors = environment == "Test" || environment == Environments.Development;
        
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        switch (exception)
        {
            case NotImplementedException:
                Response.StatusCode = (int) HttpStatusCode.NotImplemented;
                return Attempt.Fail(exception.Message);

            case UnauthorizedAccessException:
                Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                return Attempt.Fail(exception.Message);

            default:
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                _logger.LogError(exception, exception.Message);
                return useDetailedErrors ? Attempt.Fail(exception) : Attempt.Fail(exception.Message);
        }
    }
}