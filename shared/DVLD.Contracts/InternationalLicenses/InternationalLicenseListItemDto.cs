using System;

namespace DVLD.Contracts.InternationalLicenses
{
    public sealed record InternationalLicenseListItemDto
    {
        public int InternationalLicenseId { get; init; }
        public int ApplicationId { get; init; }
        public int DriverId { get; init; }
        public int LocalLicenseId { get; init; }
        public int PersonId { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string NationalNo { get; init; } = string.Empty;
        public DateTime IssueDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public bool IsActive { get; init; }
    }
}
