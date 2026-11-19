using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    public sealed record ReplacementLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
        public ReplacmentTypeEnum ReplacmentType { get; init; }
        public string? Notes { get; init; }
    }
}
