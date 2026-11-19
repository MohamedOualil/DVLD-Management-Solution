using System;

namespace DVLD.Contracts.LocalLicenseApplications
{
    public sealed record LocalApplicationBannerDto
    {
        public int LocalId { get; init; }
        public int ApplicationId { get; init; }
        public int PersonId { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public int Age { get; init; }
        public string? PersonImagePath { get; init; }
        public required string LicenseClassName { get; init; }
        public required string Status { get; init; }
    }
}
