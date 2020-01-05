using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mioddleware.Middlewares
{
    public class BrowserMiddleware
    {
        private readonly RequestDelegate _next;
            public BrowserMiddleware(RequestDelegate next)
            {
            _next = next;
            }
            public Task Invoke(HttpContext httpContext)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
                var url = httpContext.Request.Path;
                Debug.WriteLine("User Agent: " + userAgent);
                Debug.WriteLine("IProgress: " + url);
                return _next(httpContext);
            }

        }
        public static class BrowserMiddlewareExtensions
        {
            public static IApplicationBuilder UseBrowserMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<BrowserMiddleware>();
            }
        }
    }

