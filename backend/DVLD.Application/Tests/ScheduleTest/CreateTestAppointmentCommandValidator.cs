using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Tests.ScheduleTest
{
    public sealed class CreateTestAppointmentCommandValidator : IValidate<CreateTestAppointmentCommand>
    {
        public Result Validate(CreateTestAppointmentCommand request)
        {
            List<Error> errors = new(3);
            if (request.LocalApplicationId <= 0)
                errors.Add(DomainErrors.erLocalApplications.InvalidId);

            if (request.AppointmentDate <= DateTime.UtcNow)
                errors.Add(DomainErrors.erTestAppointment.InvalidAppointmentDate);

            if (!Enum.IsDefined(request.TestType))
                errors.Add(DomainErrors.erTests.InvalidTestType);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
