using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieDatabase.Application.Validation.ValidationExceptions;
using MovieDatabase.Infrastructure.ExceptionHandling.Exceptions;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using ValidationException = MovieDatabase.Application.Validation.ValidationExceptions.ValidationException;

namespace MovieDatabase.Infrastructure.ExceptionHandling.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IWebHostEnvironment env;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            this.next = next;
            this.env = env;
        }
        public async Task Invoke(HttpContext httpContext, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                var responseObj = GetErrorResponse(ex, out var statusCode);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = statusCode;
                await httpContext.Response.Body.WriteAsync(
                    JsonSerializer.SerializeToUtf8Bytes(
                        responseObj, new JsonSerializerOptions { IgnoreNullValues = true }));
            }
        }
        private object GetErrorResponse(Exception e, out int statusCode)
        {
            var errorResponse = new ExceptionResult
            {
                Message = e.Message
            };

            if (env.IsDevelopment())
            {
                errorResponse.StackTrace = e.StackTrace;
            }

            statusCode = StatusCodes.Status500InternalServerError;

            if (e is UnauthorizedException)
            {
                statusCode = StatusCodes.Status401Unauthorized;
            }

            if (e is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
            }

            if (e is ValidationException)
            {
                statusCode = StatusCodes.Status400BadRequest;
            }
            return errorResponse;
        }
    }
}
