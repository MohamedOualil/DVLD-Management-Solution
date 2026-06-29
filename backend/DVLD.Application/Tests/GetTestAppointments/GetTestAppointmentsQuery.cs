using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestAppointments
{
    public sealed record GetTestAppointmentsQuery : IQuery<List<TestAppointmentsRespond>>
    {
        public int LocalApplicationId { get; init; }
        public int TestTypeId { get; init; }

    }
}
