using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public interface IListTestAppointmentsView
    {
        event EventHandler CreateAppointmentRequested;
        event EventHandler BackRequested;
        event EventHandler<int>? RecordResultRequested;
        void DisplayApplication(ApplicationDetailDto application, TestTypeEnum testType);
        void DisplayProgress(TestResultsRoadmapDto roadmap);
        void DisplayTestAppointments(IEnumerable<TestAppointmentsRespondDto> testAppointments);
        void SetSchedulingAvailability(bool allowed, string message);
        void DisplayMessage(string message);
    }
}
