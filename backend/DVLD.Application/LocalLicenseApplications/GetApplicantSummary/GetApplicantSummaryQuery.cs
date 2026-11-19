using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.LocalLicenseApplications;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    public sealed record GetApplicantSummaryQuery(int personId, int applicationTypeId)
        : IQuery<ApplicantSummaryRespond>;
}
