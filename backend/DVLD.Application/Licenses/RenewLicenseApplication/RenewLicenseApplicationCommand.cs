using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.RenewLicenseApplication
{
    public sealed record RenewLicenseApplicationCommand : ICommand<int>
    {
        public int LicensesID { get; init; }
        public int CreatedById { get; init; }
        public string? Notes { get; init; }
    }
}
