using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense
{
    public sealed record GetInternationalLicenseQuery(int internationalLicenseId) : IQuery<GetInternationalLicenseResponse>
    {
    }
}
