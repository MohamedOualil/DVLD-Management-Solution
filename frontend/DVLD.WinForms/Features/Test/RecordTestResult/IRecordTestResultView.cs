using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Test_Appointments;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test.RecordTestResult
{
    public interface IRecordTestResultView
    {
        event EventHandler? SaveRequested;
        event EventHandler? CancelRequested;
        bool? Passed { get; }
        string Notes { get; }
        void DisplayApplication(ApplicationDetailDto application);
        void DisplayAppointment(TestAppointmentsRespondDto appointment,
            TestTypeEnum type, int attempt);
        void SetRecordingAvailability(bool allowed, string message);
        void SetSaving(bool saving);
        void DisplayMessage(string message);
    }
}

