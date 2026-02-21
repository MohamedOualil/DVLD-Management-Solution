using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplication
{
    public sealed record GetLocalApplicationQuery(int LocalApplicationId) : IQuery<LocalApplicationResponse>
    {
    }
}
