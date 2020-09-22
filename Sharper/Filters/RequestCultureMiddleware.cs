using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharper.Filters
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            Console.WriteLine($"api 请求进来了，action{context.Request.Path}");
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
