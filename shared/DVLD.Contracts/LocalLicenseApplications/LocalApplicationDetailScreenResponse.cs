using DVLD.Contracts.Persons;
using DVLD.Contracts.Tests;
using System;

namespace DVLD.Contracts.LocalLicenseApplications
{
    public sealed record LocalApplicationDetailScreenResponse
    {
        public int LocalApplicationId { get; init; }
        public int ApplicationId { get; init; }
        public required string ApplicationType { get; init; }
        public int LicenseClassId { get; init; }
        public required string LicenseClassName { get; init; }
        public decimal PaidFees { get; init; }
        public DateTime ApplicationDate { get; init; }
        public DateTime? LastStatusDate { get; init; }
        public required string Status { get; init; }
        public required string CreatedBy { get; init; }
        public int? IssuedLicenseId { get; init; }

        public required PersonResponse Applicant { get; init; }
        public required TestRoadmapResponse TestRoadmap { get; init; }
    }
}
