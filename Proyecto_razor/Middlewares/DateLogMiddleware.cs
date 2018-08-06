using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Proyecto_razor.Middlewares
{
    public class DateLogMiddleware
    {
        private readonly RequestDelegate _next;
        public DateLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            Debug.WriteLine("Date: "+DateTime.Now.ToLongDateString());
            return _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DateLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseDateLogMiddleware(this
        IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateLogMiddleware>();
        }
    }
}
