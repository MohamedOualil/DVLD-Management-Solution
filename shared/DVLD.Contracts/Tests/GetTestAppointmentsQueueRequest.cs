namespace DVLD.Contracts.Tests
{
    public sealed record GetTestAppointmentsQueueRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string? SearchTerm { get; init; }
        public int StageFilter { get; init; } = 0;  // 0=All, 1=Vision, 2=Written, 3=Street, 4=Ready
        public int StatusFilter { get; init; } = 1; // 0=All, 1=New, 2=Cancelled, 3=Completed
    }
}
