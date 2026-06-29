using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestAppointments
{
    public record TestAppointmentsRespond
    {
        public int TestAppointmentId { get; init; }
        public DateTime AppointmentDate { get; init; }
        public decimal PaidFees { get; init; }
        public required string TestResult { get; init; }
        public required string TestStatus { get; init; }
    }
}
