using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DVLD.Application.LocalLicenseApplications.CreateApplication
{
    public sealed record LocalDrivingLicenseApplicationCommand : ICommand<int>
    {
        public int PersonId { get; init; }
        public int LicensesClassId { get; init; }
        public int CreatedBy { get; init; }
    }
}
