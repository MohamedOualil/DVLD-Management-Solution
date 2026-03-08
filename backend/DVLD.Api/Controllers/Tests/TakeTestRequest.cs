using DVLD.Domain.Enums;

namespace DVLD.Api.Controllers.Tests
{
    public sealed record TakeTestRequest
    {
        public int TestAppointmentId { get; init; }
        public TestResult Result { get; init; }
        public string? Notes { get; init; }
        public int CreateById { get; init; }
    }
}
