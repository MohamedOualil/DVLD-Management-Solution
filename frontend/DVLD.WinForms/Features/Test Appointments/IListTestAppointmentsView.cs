using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public interface IListTestAppointmentsView
    {
        void DisplayTestAppointments(IEnumerable<TestAppointmentsRespondDto> testAppointments);
        event EventHandler CreateAppointmentRequested; 
        void DisplayMessage(string message);
    }
}
