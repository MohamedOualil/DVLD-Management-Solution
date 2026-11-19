using DVLD.Contracts.Auth;
using Microsoft.AspNetCore.Diagnostics;

namespace DVLD.Api.Common
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger,
            IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "Unhandled exception processing {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);

            var message = _environment.IsDevelopment()
                ? exception.Message
                : "An unexpected internal server error occurred. Please try again later.";

            var response = new ErrorResponse
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Errors =
                [
                    new ErrorDetail
                    {
                        Code = "Server.InternalError",
                        Message = message
                    }
                ]
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
