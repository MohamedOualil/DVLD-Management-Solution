using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    public record DriversListResponse
    {
        public required int DriverId { get; init; }
        public required int PersonId { get; init; }
        public required string NationNo { get; init; }
        public required string FullName { get; init; }
        public required DateTime CreateDate { get; init; }
        public required int ActiveLicenses { get; init; }

    }
}
