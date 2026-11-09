using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Tests
{
    public sealed record CreateTestRequest
    {
        public int LocalApplicationId { get; init; }
        public DateTime AppointmentDate { get; init; }
        public TestTypeEnum TestType { get; init; }
    }
}
