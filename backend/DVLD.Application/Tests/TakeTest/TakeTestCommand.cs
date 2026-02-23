using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DVLD.Application.Tests.TakeTest
{
    public sealed record TakeTestCommand : ICommand<int>
    {
        public int TestAppointmentId { get; init; }
        public TestResult Result { get; init; }
        public string? Notes { get; init; }
        public int CreateById { get; init; }
    }
}
