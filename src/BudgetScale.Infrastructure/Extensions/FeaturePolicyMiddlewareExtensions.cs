using BudgetScale.Infrastructure.Middlewares.Security;
using Microsoft.AspNetCore.Builder;

namespace BudgetScale.Infrastructure.Extensions
{
    public static class FeaturePolicyMiddlewareExtensions
    {
        public static IApplicationBuilder UseFeaturePolicy(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FeaturePolicyMiddleware>();
        }
    }
}