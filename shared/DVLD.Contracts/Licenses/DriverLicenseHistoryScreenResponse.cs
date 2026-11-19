using DVLD.Contracts.Common;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Persons;

namespace DVLD.Contracts.Licenses
{
    public sealed record DriverLicenseHistoryScreenResponse
    {
        public required PersonResponse Person { get; init; }
        public required PagedList<GetLocalDrivingLicenseHistoryResponse> LocalLicenses { get; init; }
        public required PagedList<GetInternationalDrivingLicenseHistoryResponse> InternationalLicenses { get; init; }
    }
}
