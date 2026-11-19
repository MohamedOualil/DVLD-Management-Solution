using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.ReferenceData;

namespace DVLD.Application.ReferenceData.GetLicenseClasses
{
    public sealed record GetLicenseClassesQuery : IQuery<List<LicenseClassDto>>;
}
