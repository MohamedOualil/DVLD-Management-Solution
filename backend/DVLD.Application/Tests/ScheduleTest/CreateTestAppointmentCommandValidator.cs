using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.ScheduleTest
{
    public sealed class CreateTestAppointmentCommandValidator : IValidate<CreateTestAppointmentCommand>
    {
        public Result Validate(CreateTestAppointmentCommand request)
        {
            List<Error> errors = new(4);
            if (request.LocalApplicationId <= 0)
                errors.Add(DomainErrors.erLocalApplications.InvalidId);

            if (request.CreatedById <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (request.AppointmentDate < DateTime.UtcNow)
                errors.Add(DomainErrors.erTestAppointment.InvalidAppoinmentDate);

            if (!Enum.IsDefined(request.TestType))
                errors.Add(DomainErrors.erTests.InvalidTestType);

            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();

        }
    }
}
