using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.LocalLicenseApplications.UpdateLocalApplication
{
    public sealed record UpdateDrivingLicenceApplicationCommand : ICommand
    {
        public int LocalApplicationId { get; init; }
        public LicenseClassEnum LicenseClass { get; init; }
    }
}
