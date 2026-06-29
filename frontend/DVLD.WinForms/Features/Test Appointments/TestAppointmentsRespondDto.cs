using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public class TestAppointmentsRespondDto
    {
        public int TestAppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public string TestStatus { get; set; } = string.Empty;
        public string TestResult { get; set; } = string.Empty;
    }
}
