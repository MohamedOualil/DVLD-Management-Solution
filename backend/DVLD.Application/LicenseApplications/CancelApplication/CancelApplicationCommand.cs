using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.LicenseApplications.CancelApplication
{
    public sealed record CancelApplicationCommand(int ApplicationId) : ICommand;
}
