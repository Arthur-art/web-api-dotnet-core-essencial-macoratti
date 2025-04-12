using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace web_api_catalog.Extensions
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static void ConfigureExcepetionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        };

                        var errorJson = JsonSerializer.Serialize(errorDetails);
                        await context.Response.WriteAsync(errorJson);
                    }
                });
            });
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }
    }
}
