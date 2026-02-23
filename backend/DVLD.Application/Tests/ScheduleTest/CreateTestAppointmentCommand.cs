using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.ScheduleTest
{
    public sealed record CreateTestAppointmentCommand : ICommand<int>
    {
        public int LocalApplicationId { get; init; }
        public int CreatedById { get; init; }
        public DateTime AppointmentDate { get; init; }
        public TestType TestType { get; init; }
    }
}
