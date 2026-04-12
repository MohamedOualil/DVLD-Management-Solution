using DVLD.WinForms.Shared.Events;
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
        int cbStatusId { get; }
        event EventHandler OnLoadDataRequested;
        event EventHandler OnSearchChangeRequested;
        event EventHandler<ApplicationMenuEventArgs> OnOpeningLocalAppActionMenu;

        bool IsEditOptionEnabled { set; }
        bool IsCancelOptionEnabled { set; }
        bool IsDeleteOptionEnabled { set; }
        bool IsIssueLicenseOptionEnabled { set; }
        public bool IsScheduleTestOptionEnabled {  set; }
        public bool IsShowLicenceOptionEnabled {  set; }

        bool IsScheduleVisionTestEnabled { set; }
        bool IsScheduleWrittenTestEnabled { set; }
        bool IsScheduleStreetTestEnabled { set; }

        void DisplayMessage(string message);
        void DisplayLocalApplications(IEnumerable<LocalApplicationsDto> localApplications);
    }
}
