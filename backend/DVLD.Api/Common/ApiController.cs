using DVLD.Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Common
{
    public abstract  class ApiController : ControllerBase
    {
        protected  ActionResult HandleFailure (Result result) 
        {
            if (result.IsSuccess)
                throw new InvalidOperationException(
                    "HandleFailure called on a successful result.");

            var errorResponse = BuildErrorResponse(result.Errors);

            return errorResponse.Status switch
            {
                StatusCodes.Status404NotFound => NotFound(errorResponse),
                StatusCodes.Status409Conflict => Conflict(errorResponse),
                StatusCodes.Status401Unauthorized => Unauthorized(errorResponse),
                _ => BadRequest(errorResponse)
            };

        }

        protected ActionResult HandleFailure(Result result, Error error)
        {
            var errorResponse = new ErrorResponse
            {
                Title = GetTitle(error.Type),
                Status = GetStatusCode(error.Type),
                Errors = new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Code    = error.code,
                        Message = error.Name
                    }
                }
            };

            return errorResponse.Status switch
            {
                StatusCodes.Status404NotFound => NotFound(errorResponse),
                StatusCodes.Status409Conflict => Conflict(errorResponse),
                _ => BadRequest(errorResponse)
            };
        }

        private static ErrorResponse BuildErrorResponse (IReadOnlyList<Error> errors)
        {
            ErrorType errorType = errors.Count > 0
                ? errors[0].Type
                : ErrorType.BadRequest;

            if (errors.Any(e => e.Type == ErrorType.NotFound))
                errorType = ErrorType.NotFound;

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
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.BadRequest => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status400BadRequest
            };

        private static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.NotFound => "Resource Not Found",
                ErrorType.Unauthorized => "Unauthorized",
                ErrorType.Conflict => "Conflict",
                ErrorType.BadRequest => "Bad Request",
                _ => "Bad Request"
            };


    }
}
