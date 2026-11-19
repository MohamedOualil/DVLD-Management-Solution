using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Tests.RescheduleTest
{
    public sealed record RescheduleTestAppointmentCommand(
        int AppointmentId,
        DateTime NewAppointmentDate) : ICommand;
}
