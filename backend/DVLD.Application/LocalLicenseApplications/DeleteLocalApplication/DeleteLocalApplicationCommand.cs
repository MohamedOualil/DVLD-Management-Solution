using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.LocalLicenseApplications.DeleteLocalApplication
{
    public sealed record DeleteLocalApplicationCommand(int LocalApplicationId) : ICommand;
}
