using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Tests.Appointments;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Tests.RecordTestResult
{
    public interface IRecordTestResultView
    {
        event EventHandler? SaveRequested;
        event EventHandler? HasChangesRequested;
        bool? Passed { get; }
        string Notes { get; }
        void DisplayApplication(LocalApplicationResponse application);
        void DisplayAppointment(TestAppointmentsRespond appointment,
            TestTypeEnum type, int attempt);
        void SetRecordingAvailability(bool allowed, string message);
        void SetSaving(bool saving);
        void DisplayMessage(string message);
    }
}

