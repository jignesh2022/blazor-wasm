using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProject.Server.Middlewares
{    
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> _logger)
        {
            _next = next;
            logger = _logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {                 
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddleware> logger)
        {
            logger.LogError($"{exception.Message} | {exception.StackTrace.Substring(0, exception.StackTrace.IndexOf(@":line") + 10)}");

            HttpStatusCode status;
            string message;
            
            var exceptionType = exception.GetType();
            
            if (exceptionType == typeof(BadHttpRequestException)) 
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(FileNotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else  
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                /*if (env.IsEnvironment("Development"))
                    stackTrace = exception.StackTrace;*/
            }

            
            var result = JsonSerializer.Serialize(new { status = status, error = message });
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
