using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsView
    {
        event EventHandler OnLoadDataRequested;
        void DisplayLocalApplications(IEnumerable<LocalApplicationsDto> localApplications);
    }
}
