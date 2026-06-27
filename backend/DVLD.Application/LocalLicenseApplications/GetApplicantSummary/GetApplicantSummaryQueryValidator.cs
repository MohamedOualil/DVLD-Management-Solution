using DVLD.Application.Abstractions;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    public sealed class GetApplicantSummaryQueryValidator: IValidate<GetApplicantSummaryQuery>
    {
        public Result Validate(GetApplicantSummaryQuery request)
        {
            List<Error> errors = new(2);

            if (request.personId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.applicationTypeId <= 0)
                errors.Add(DomainErrors.erApplicationTypes.InvalidId);



            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
