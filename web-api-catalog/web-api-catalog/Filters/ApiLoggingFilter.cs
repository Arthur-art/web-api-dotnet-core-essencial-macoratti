using Microsoft.AspNetCore.Mvc.Filters;
using web_api_catalog.Context;
using web_api_catalog.Domain;

namespace web_api_catalog.Filters;

public class ApiLoggingFilter : IActionFilter
{
    private readonly ILogger<ApiLoggingFilter> _logger;
    private readonly AppDbContext _context;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
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

        var dateTime = $"Hora e data do evento: {DateTime.Now.ToLongTimeString()}, {DateTime.Now.ToLongDateString()}";
        var payload = new Logs(context.Controller.ToString(), dateTime);

        _context.logs.Add(payload);
        _context.SaveChanges();
    }



}
