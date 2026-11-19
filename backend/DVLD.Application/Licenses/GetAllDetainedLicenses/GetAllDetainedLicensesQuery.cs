using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Common;
using DVLD.Contracts.Licenses;

namespace DVLD.Application.Licenses.GetAllDetainedLicenses
{
    public sealed record GetAllDetainedLicensesQuery : IQuery<PagedList<DetainedLicenseListItemDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public int ReleaseStatus { get; init; } = 0; // 0 = All, 1 = Detained, 2 = Released
    }
}
