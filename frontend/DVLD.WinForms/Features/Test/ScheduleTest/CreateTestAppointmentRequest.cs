using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public sealed record CreateTestAppointmentRequest
    {
        public int LocalApplicationId { get; init; }
        public int CreatedById { get; init; }
        public DateTime AppointmentDate { get; init; }
        public int TestType { get; init; }
    }
}
