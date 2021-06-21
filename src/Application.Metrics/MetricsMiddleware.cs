using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Metrics
{
    public class MetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MetricsMiddleware> _logger;

        public MetricsMiddleware(
            RequestDelegate next,
            ILogger<MetricsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, ISendMetricsCommand sendMetricsCommand)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                await sendMetricsCommand.Execute();
            }
        }
    }
}
