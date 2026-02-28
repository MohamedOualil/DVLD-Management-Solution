using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DVLD.Application.Abstractions.Messaging;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense
{
    public record  ReleaseDeatinedDrivingLicenseCommand : ICommand
    {
        public int LicensesId { get; init; }
        public int RelaseBy {  get; init; }
    }
}
