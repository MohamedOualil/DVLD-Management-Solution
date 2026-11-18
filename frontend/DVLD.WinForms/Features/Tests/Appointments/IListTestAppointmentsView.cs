using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Enums;

namespace DVLD.WinForms.Features.Tests.Appointments
{
    public interface IListTestAppointmentsView
    {
        event EventHandler CreateAppointmentRequested;

        event EventHandler<int>? RecordResultRequested;
        void DisplayApplication(LocalApplicationResponse application, TestTypeEnum testType);
        void DisplayProgress(TestRoadmapResponse roadmap);
        void DisplayTestAppointments(IEnumerable<TestAppointmentsRespond> testAppointments);
        void SetSchedulingAvailability(bool allowed, string message);
        void DisplayMessage(string message);
    }
}
