using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Tests.RescheduleTest
{
    public sealed class RescheduleTestAppointmentCommandValidator : IValidate<RescheduleTestAppointmentCommand>
    {
        public Result Validate(RescheduleTestAppointmentCommand request)
        {
            List<Error> errors = new(2);

            if (request.AppointmentId <= 0)
                errors.Add(DomainErrors.erTestAppointment.InvalidId);

            if (request.NewAppointmentDate <= DateTime.UtcNow)
                errors.Add(DomainErrors.erTestAppointment.InvalidAppointmentDate);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
