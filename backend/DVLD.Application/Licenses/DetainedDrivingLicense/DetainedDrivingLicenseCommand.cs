using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    public sealed record DetainedDrivingLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
        public decimal Fees { get; init; }
        public int CreatedBy { get; init; }
    }
}
