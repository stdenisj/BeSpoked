using BeSpoked.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SermonCentral.Spark.Models;

namespace BeSpoked.Api.Utilities;

public class ServerResponseForExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public ServerResponseForExceptionsMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);

        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted)
            {
                throw;
            }
            context.Response.Clear();
            context.Response.ContentType = @"application/json";
            
            if (ex is ModelValidationException modelValidationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var fieldErrors = modelValidationException
                    .ValidationErrors
                    .GroupBy(e => e.Field, e => e.ErrorMessage)
                    .Select(errorGroup => new ModelStateError() { Field = errorGroup.Key, Errors = errorGroup });

                var response = new ModelStateValidation() { Errors = fieldErrors };

                var jsonResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                await context.Response.WriteAsync(jsonResponse);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var response = new ServerResponse("Server Error");
                var jsonResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ServerResponseForExceptionsMiddlewareExtensions
{
    public static IApplicationBuilder UseServerResponseForExceptions(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ServerResponseForExceptionsMiddleware>();
    }
}