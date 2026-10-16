namespace DVLD.WinForms.Features.Test.RecordTestResult
{
    public sealed record RecordTestResultRequest
    {
        public int TestAppointmentId { get; init; }
        // Matches backend TestResult: Success = 1, Failure = 0.
        public int Result { get; init; }
        public string? Notes { get; init; }
        public int CreateById { get; init; }
    }

    // POST Test/Take returns Result<int>, rather than the ID alone.
    public sealed record RecordTestResultResponse
    {
        public bool IsSuccess { get; init; }
        public int Value { get; init; }
    }
}
