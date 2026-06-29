using DVLD.Application.Abstractions;
using DVLD.Application.LocalLicenseApplications.GetApplicantSummary;
using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestAppointments
{
    public sealed class GetTestAppointmentsQueryValidator : IValidate<GetTestAppointmentsQuery>
    {
        public Result Validate(GetTestAppointmentsQuery request)
        {
            List<Error> errors = new(3);

            if (request.LocalApplicationId <= 0)
                errors.Add(DomainErrors.erLocalApplications.InvalidId);

            if (request.TestTypeId <= 0)
                errors.Add(DomainErrors.erTestTypes.InvalidId);


            if (Enum.IsDefined(typeof(TestTypeEnum), request.TestTypeId))
            {
                errors.Add(DomainErrors.erTestTypes.InvalidId);
            }


            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
