using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public interface INewLocalDrivingLicenseView
    {
        bool IsEnableNextStepButton { set; }
        void DisplayMessage(string message);
        bool MessageLabel { set; }
        void ShowChildView(object childView);
    }
}
