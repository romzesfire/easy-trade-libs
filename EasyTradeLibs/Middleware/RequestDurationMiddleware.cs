using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EasyTrade.API.Validation;

public class RequestDurationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestDurationMiddleware> _logger;
    public RequestDurationMiddleware(RequestDelegate next, ILogger<RequestDurationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var duration = new Stopwatch();
        duration.Start();
        await _next(httpContext);
        duration.Stop();
        
        _logger.LogInformation("Request method {method} {url} duration - {duration}ms", 
            httpContext.Request.Method, httpContext.Request.Path.ToString(), duration.ElapsedMilliseconds);
    }
}