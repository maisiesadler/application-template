using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Minimal.Endpoints
{
    public static class EndpointProcessor
    {
        public static Func<HttpContext, Task> Process<TEndpoint>(this IEndpointRouteBuilder endpoints)
            where TEndpoint : IEndpoint
        {
            return async httpContext =>
                endpoints.ServiceProvider.GetRequiredService<ValidationEndpoint>().Execute(httpContext);
        }
    }
}
