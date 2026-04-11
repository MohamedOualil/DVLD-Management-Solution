using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Dashboard
{
    public interface IAdminDashboardView
    {
        Control MainContentPanel { get; }
        event EventHandler OnLoadApplicationsClicked;
    }
}
