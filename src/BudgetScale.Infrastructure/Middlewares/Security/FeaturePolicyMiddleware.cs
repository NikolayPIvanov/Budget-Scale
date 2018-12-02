using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BudgetScale.Infrastructure.Middlewares.Security
{
    public class FeaturePolicyMiddleware
    {
        private readonly RequestDelegate _next;

        public FeaturePolicyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Feature-Policy", "geolocation \'none\'");
            await this._next(httpContext);
        }
    }
}