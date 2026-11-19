using DVLD.Contracts.Enums;
using System;

namespace DVLD.Contracts.Licenses
{
    public sealed record GetLicenseDetailResponse
    {
        public int LicenseId { get; init; }
        public int ApplicationId { get; init; }
        public int DriverId { get; init; }
        public int PersonId { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public short Gender { get; init; }
        public string? ImagePath { get; init; }
        public int LicenseClassId { get; init; }
        public required string ClassName { get; init; }
        public int DefaultValidityYears { get; init; }
        public DateTime IssueDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public string? Notes { get; init; }
        public bool IsActive { get; init; }
        public IssueReasonEnum IssueReason { get; init; }

        // Detention state
        public bool IsDetained { get; init; }
        public int? ActiveDetainId { get; init; }
        public DateTime? DetainDate { get; init; }
        public decimal? FineFees { get; init; }

        // Associated Service Fees
        public decimal ClassLicenseFee { get; init; }
        public decimal RenewalApplicationFee { get; init; }
        public decimal DamagedReplacementFee { get; init; }
        public decimal LostReplacementFee { get; init; }
        public decimal ReleaseDetainedApplicationFee { get; init; }
        public decimal InternationalPermitApplicationFee { get; init; }
    }
}
