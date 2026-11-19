using DVLD.Contracts.Common;
using DVLD.Contracts.LocalLicenseApplications;

namespace DVLD.Contracts.Tests
{
    public sealed record ManageTestAppointmentsQueueResponse
    {
        public int TotalActiveExamsCount { get; init; }
        public int VisionQueueCount { get; init; }
        public int WrittenQueueCount { get; init; }
        public int StreetQueueCount { get; init; }
        public required PagedList<GetAllLocalApplicationsResponse> Applications { get; init; }
    }
}
