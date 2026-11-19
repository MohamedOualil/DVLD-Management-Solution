using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Licenses;

namespace DVLD.Application.Licenses.GetLicenseDetail
{
    public sealed record GetLicenseDetailQuery(int LicenseId) : IQuery<GetLicenseDetailResponse>;
}
