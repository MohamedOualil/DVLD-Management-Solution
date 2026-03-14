using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetLocalDrivingLicenseHistory
{
    public sealed record GetLocalDrivingLicenseHistoryQuery : IQuery<PagedList<GetLocalDrivingLicenseHistoryResponse>>
    {
        public required string NationalNo { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
