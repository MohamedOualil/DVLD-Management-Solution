using System;

namespace DVLD.Contracts.LocalLicenseApplications
{
    public sealed record IssueDrivingLicenseScreenResponse
    {
        public int LocalId { get; init; }
        public int ApplicationId { get; init; }
        public int PersonId { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public int Age { get; init; }
        public string? PersonImagePath { get; init; }
        public required string ApplicationType { get; init; }
        public int LicenseClassId { get; init; }
        public required string LicenseClassName { get; init; }
        public decimal PaidFees { get; init; }
        public DateTime ApplicationDate { get; init; }
        public DateTime? LastStatusDate { get; init; }
        public required string Status { get; init; }
        public required string CreatedBy { get; init; }
        public int PassedTestsCount { get; init; }
        public bool IsEligibleToIssue { get; init; }
    }
}
