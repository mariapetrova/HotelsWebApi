using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Hotels.Api.Core.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private static readonly Action<ILogger, Exception> _globalLogger = LoggerMessage.Define(
                LogLevel.Error,
                new EventId(1, nameof(GlobalExceptionMiddleware)),
                string.Empty);

        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _globalLogger(_logger, ex);
                throw;
            }
        }
    }
}
