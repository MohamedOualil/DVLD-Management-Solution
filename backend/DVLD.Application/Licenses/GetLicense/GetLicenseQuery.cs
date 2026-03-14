using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetLicense
{
    public sealed record GetLicenseQuery(int LicenseId) : IQuery<GetLicenseResponse>
    {
    }
}
