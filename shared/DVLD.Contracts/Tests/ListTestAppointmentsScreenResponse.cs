using DVLD.Contracts.LocalLicenseApplications;
using System.Collections.Generic;

namespace DVLD.Contracts.Tests
{
    public sealed record ListTestAppointmentsScreenResponse
    {
        public required LocalApplicationBannerDto Application { get; init; }
        public required TestRoadmapResponse Roadmap { get; init; }
        public IReadOnlyList<TestAppointmentsRespond> Appointments { get; init; } = [];
        public bool CanScheduleNewAppointment { get; init; }
        public string SchedulingStatusMessage { get; init; } = string.Empty;
    }
}
