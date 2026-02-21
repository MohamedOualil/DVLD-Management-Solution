using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DVLD.Application.Abstractions.Messaging;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.LicenseApplications.CancelApplication
{
    public sealed record CancelApplicationCommand(int ApplicationId,int CancelBy) : ICommand { }


}
