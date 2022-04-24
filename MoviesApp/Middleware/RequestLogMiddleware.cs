using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, ILogger<RequestLogMiddleware> logger)
        {
            logger.LogTrace($"Request: {httpContext.Request.Path} Method: {httpContext.Request.Method} Host: {httpContext.Request.Host}");
            
            if (httpContext.Request.Path.StartsWithSegments("/Actors"))
            {
                logger.LogTrace($"Request: {httpContext.Request.Path} Method: {httpContext.Request.Method} Host: {httpContext.Request.Host}");
            }
            
            await _next(httpContext);
        }
    }
}