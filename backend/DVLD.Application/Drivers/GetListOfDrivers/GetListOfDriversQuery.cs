using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    public record GetListOfDriversQuery : IQuery<PagedList<DriversListResponse>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int? PersonId { get; init; } = null;
        public string? NationNo { get; init; } = null;
        public string? Name { get; init; } = null;
        public int? DriverId { get; init; } = null;
    }
}
