using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public interface IScheduleTestView
    {
        void DisplayTestInfo(SchelduleTestDto testInfo);
        void DisplayMessage(string message);
        void SetSaving(bool isSaving);
        event EventHandler SaveRequested;
        event EventHandler CancelRequested;

        DateTime AppointmentDate { get; }
    }
}
