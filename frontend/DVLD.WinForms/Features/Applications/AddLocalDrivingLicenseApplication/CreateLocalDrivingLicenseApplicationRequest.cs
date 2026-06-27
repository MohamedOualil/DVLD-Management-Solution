using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public record CreateLocalDrivingLicenseApplicationRequest
    {
        public int PersonId { get; init; }
        public int LicensesClassId { get; init; }
    }
}
