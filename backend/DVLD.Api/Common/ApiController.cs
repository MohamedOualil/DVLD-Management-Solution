using DVLD.Contracts.Auth;
using DVLD.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Common
{
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult HandleFailure(Result result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException("HandleFailure called on a successful result.");

            var errorResponse = BuildErrorResponse(result.Errors);

            return errorResponse.Status switch
            {
                StatusCodes.Status404NotFound => NotFound(errorResponse),
                StatusCodes.Status409Conflict => Conflict(errorResponse),
                StatusCodes.Status401Unauthorized => Unauthorized(errorResponse),
                StatusCodes.Status403Forbidden => StatusCode(StatusCodes.Status403Forbidden, errorResponse),
                _ => BadRequest(errorResponse)
            };
        }

        private static ErrorResponse BuildErrorResponse(IReadOnlyList<Error> errors)
        {
            ErrorType errorType = errors.Count > 0
                ? errors[0].Type
                : ErrorType.BadRequest;

            if (errors.Any(e => e.Type == ErrorType.NotFound))
                errorType = ErrorType.NotFound;
            else if (errors.Any(e => e.Type == ErrorType.Forbidden))
                errorType = ErrorType.Forbidden;
            else if (errors.Any(e => e.Type == ErrorType.Unauthorized))
                errorType = ErrorType.Unauthorized;

            return new ErrorResponse
            {
                Title = GetTitle(errorType),
                Status = GetStatusCode(errorType),
                Errors = errors.Select(e => new ErrorDetail
                {
                    Code = e.code,
                    Message = e.Name,
                }).ToList()
            };
        }

        private static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.BadRequest => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status400BadRequest
            };

        private static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.NotFound => "Resource Not Found",
                ErrorType.Unauthorized => "Unauthorized",
                ErrorType.Forbidden => "Forbidden",
                ErrorType.Conflict => "Conflict",
                ErrorType.BadRequest => "Bad Request",
                _ => "Bad Request"
            };
    }
}
