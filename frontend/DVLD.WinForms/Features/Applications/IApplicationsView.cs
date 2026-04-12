using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsView
    {
        string SearchTerm { get; }
        int StatusId { get; }
        event EventHandler OnLoadDataRequested;
        event EventHandler OnSearchChangeRequested;

        void DisplayMessage(string message);
        void DisplayLocalApplications(IEnumerable<LocalApplicationsDto> localApplications);
    }
}
