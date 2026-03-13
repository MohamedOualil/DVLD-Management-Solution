using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    public sealed record GetAllLocalApplicationsQuery : IQuery<PagedList<GetAllLocalApplicationsResponse>>
    {
        public  int PageNumber { get; init; } = 1;
        public  int PageSize { get; init; } = 10;

    }
}
