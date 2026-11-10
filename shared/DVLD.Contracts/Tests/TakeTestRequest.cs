using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Tests
{
    public sealed record TakeTestRequest
    {
        public int TestAppointmentId { get; init; }
        public TestResult Result { get; init; }
        public string? Notes { get; init; }
    }
}
