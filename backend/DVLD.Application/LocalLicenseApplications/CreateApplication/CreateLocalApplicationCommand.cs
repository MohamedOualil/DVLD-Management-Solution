using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.LocalLicenseApplications.CreateApplication
{
    public sealed record CreateLocalApplicationCommand : ICommand<int>
    {
        public int PersonId { get; init; }
        public int LicensesClassId { get; init; }
    }
}
