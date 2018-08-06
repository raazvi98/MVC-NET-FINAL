using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace Proyecto_razor.Middlewares
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
            Debug.WriteLine("Ip: " + ipAddress);
            Debug.WriteLine("Url: " + url);
            return _next(httpContext);
        }
        
    }
    public static class BrowserMiddleWareExtensions
    {
        public static IApplicationBuilder UseBrowserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserMiddleware>();
        }

    }
}
