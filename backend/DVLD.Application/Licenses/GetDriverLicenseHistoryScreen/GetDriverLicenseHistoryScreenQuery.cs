using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Licenses;

namespace DVLD.Application.Licenses.GetDriverLicenseHistoryScreen
{
    public sealed record GetDriverLicenseHistoryScreenQuery(
        int PersonId,
        int PageNumber = 1,
        int PageSize = 10,
        int? LocalPageNumber = null,
        int? LocalPageSize = null,
        int? InternationalPageNumber = null,
        int? InternationalPageSize = null) : IQuery<DriverLicenseHistoryScreenResponse>;
}
