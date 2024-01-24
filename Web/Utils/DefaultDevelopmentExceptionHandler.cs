using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Utils;

/// <summary>
/// Обработчик всех ошибок на этапе разработки
/// </summary>
/// <param name="logger"> Логгер </param>
public class DefaultDevelopmentExceptionHandler(ILogger<DefaultDevelopmentExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception e, CancellationToken token)
    {
        logger.LogError(e, $"Exception occurred: {e.Message}");

        await ctx.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = "Server error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = e.Message,
            Type = e.GetType().Name,
            Instance = $"{ctx.Request.Method} {ctx.Request.Path}",
        }, token);
        
        return true;
    }
}