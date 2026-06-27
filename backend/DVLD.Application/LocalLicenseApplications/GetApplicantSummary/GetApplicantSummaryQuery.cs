using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    public sealed record GetApplicantSummaryQuery(int personId,int applicationTypeId): IQuery<ApplicantSummaryRespond>
    {
    }
}
