using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Common;
using DVLD.Contracts.InternationalLicenses;

namespace DVLD.Application.InternationalDrivingLicenses.GetAllInternationalLicenses
{
    public sealed record GetAllInternationalLicensesQuery : IQuery<PagedList<InternationalLicenseListItemDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public int StatusFilter { get; init; } = 0; // 0 = All, 1 = Active, 2 = Expired
    }
}
