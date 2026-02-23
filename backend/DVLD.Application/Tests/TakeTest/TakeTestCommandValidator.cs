using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.TakeTest
{
    public sealed class TakeTestCommandValidator : IValidate<TakeTestCommand>
    {
        public Result Validate(TakeTestCommand request)
        {
            List<Error> errors = new(3);
            if (request.TestAppointmentId <= 0)
                errors.Add(DomainErrors.erTestAppointment.InvalidId);

            if (request.CreateById <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if(!Enum.IsDefined(request.Result))
                errors.Add(DomainErrors.erTestTypes.InvalidId);

            return errors.Count == 0 ? Result.Success() : Result.Failure(errors);

        }
    }
}
