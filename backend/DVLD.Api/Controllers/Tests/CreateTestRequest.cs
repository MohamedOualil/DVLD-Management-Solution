using DVLD.Domain.Enums;

namespace DVLD.Api.Controllers.Tests
{
    public sealed record CreateTestRequest
    {
        public int LocalApplicationId { get; init; }
        public int CreatedById { get; init; }
        public DateTime AppointmentDate { get; init; }
        public TestTypeEnum TestType { get; init; }
    }
}
