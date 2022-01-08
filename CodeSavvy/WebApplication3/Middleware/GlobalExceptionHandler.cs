using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeSavvy.WebUI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleGlobalExceptionAsync(httpContext, e);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new GlobalErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Something went wrong. Internal server error"
            }.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    
    public static class GlobalExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
    
}
