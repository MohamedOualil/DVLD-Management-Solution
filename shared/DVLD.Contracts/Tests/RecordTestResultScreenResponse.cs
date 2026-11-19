using DVLD.Contracts.LocalLicenseApplications;
using System;

namespace DVLD.Contracts.Tests
{
    public sealed record RecordTestResultScreenResponse
    {
        public required LocalApplicationBannerDto Application { get; init; }
        public int TestAppointmentId { get; init; }
        public int TestTypeId { get; init; }
        public required string TestName { get; init; }
        public DateTime AppointmentDate { get; init; }
        public int AttemptNumber { get; init; }
        public decimal PaidFees { get; init; }
        public required string TestStatus { get; init; }
        public required string TestResult { get; init; }
        public bool CanRecordResult { get; init; }
        public string AvailabilityMessage { get; init; } = string.Empty;
    }
}
