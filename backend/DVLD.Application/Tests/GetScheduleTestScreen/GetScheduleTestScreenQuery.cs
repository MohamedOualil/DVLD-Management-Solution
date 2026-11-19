using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Tests;

namespace DVLD.Application.Tests.GetScheduleTestScreen
{
    public sealed record GetScheduleTestScreenQuery(int LocalApplicationId, int TestTypeId)
        : IQuery<ScheduleTestScreenResponse>;
}
