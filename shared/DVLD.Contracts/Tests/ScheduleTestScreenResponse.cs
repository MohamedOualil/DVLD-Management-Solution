using System;

namespace DVLD.Contracts.Tests
{
    public sealed record ScheduleTestScreenResponse
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
        public required string LicenseClassName { get; init; }
        public int TestTypeId { get; init; }
        public required string TestName { get; init; }
        public decimal TestFees { get; init; }
        public bool IsRetake { get; init; }
        public decimal RetakeApplicationFee { get; init; }
        public decimal TotalFees { get; init; }
        public int TrialsCount { get; init; }
        public bool CanSchedule { get; init; } = true;
        public string? RestrictionMessage { get; init; }
    }
}
