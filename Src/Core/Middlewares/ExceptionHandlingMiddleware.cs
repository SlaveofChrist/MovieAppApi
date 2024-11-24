using System.Net;
using System.Text.Json;

namespace MovieAppApi.Src.Core.Middlewares;

public class ExceptionHandlingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionHandlingMiddleware> _logger;

  public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An unhandled exception occurred.");
      await HandleExceptionAsync(context, ex);
    }
  }

  private Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    var responseDev = new
    {
      StatusCode = (int)HttpStatusCode.InternalServerError,
      Message = "An unexpected error occurred.",
      Details = exception.Message,
      Trace = exception.StackTrace?.Split(Environment.NewLine)
    };

    var response = new
    {
      StatusCode = (int)HttpStatusCode.InternalServerError,
      Message = "An unexpected error occurred. Please try again later.",
    };

    var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

    var payload = isDevelopment ?
      JsonSerializer.Serialize(responseDev) :
      JsonSerializer.Serialize(response);

    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    return context.Response.WriteAsync(payload);
  }
}
