using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Tests.TakeTest
{
    public sealed class TakeTestCommandValidator : IValidate<TakeTestCommand>
    {
        public Result Validate(TakeTestCommand request)
        {
            List<Error> errors = new(2);
            if (request.TestAppointmentId <= 0)
                errors.Add(DomainErrors.erTestAppointment.InvalidId);

            if (!Enum.IsDefined(request.Result))
                errors.Add(DomainErrors.erTests.InvalidTestResult);

            return errors.Count == 0 ? Result.Success() : Result.Failure(errors);
        }
    }
}
