using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Tests;

namespace DVLD.Application.Tests.GetListTestAppointmentsScreen
{
    public sealed record GetListTestAppointmentsScreenQuery(int LocalApplicationId, int TestTypeId)
        : IQuery<ListTestAppointmentsScreenResponse>;
}
