using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Tests;

namespace DVLD.Application.Tests.GetRecordTestResultScreen
{
    public sealed record GetRecordTestResultScreenQuery(int TestAppointmentId)
        : IQuery<RecordTestResultScreenResponse>;
}
