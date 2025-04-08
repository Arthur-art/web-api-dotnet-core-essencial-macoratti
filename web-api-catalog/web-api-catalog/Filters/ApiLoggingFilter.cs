using Microsoft.AspNetCore.Mvc.Filters;

namespace web_api_catalog.Filters;

public class ApiLoggingFilter : IActionFilter
{
    private readonly ILogger<ApiLoggingFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Executando OnActionExecuting");
        _logger.LogInformation("###############################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Executando OnActionExecuted");
        _logger.LogInformation("###############################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"StatusCode {context.HttpContext.Response.StatusCode}");
    }

   
}
