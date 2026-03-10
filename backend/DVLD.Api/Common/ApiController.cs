using DVLD.Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Common
{
    public abstract  class ApiController : ControllerBase
    {
        protected  ActionResult HandleFailure (Result result) 
        {
            Error? firstError = result.Errors.FirstOrDefault();

            if (firstError == null) 
                return  BadRequest(result.Errors);

            switch (firstError.Type)
            {
                case ErrorType.NotFound:
                    return  NotFound(result.Errors);
                case ErrorType.BadRequest:
                    return  BadRequest(result.Errors);
                default:
                    return  BadRequest(result.Errors);

            }

        }
    }
}
