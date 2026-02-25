using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense
{
    public sealed record IssueInternationalLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
        public int CreatedBy { get; init; }
    }
}
