namespace DVLD.Contracts.Tests
{
    // POST Test/Take returns Result<int>, rather than the ID alone.
    public sealed record RecordTestResultResponse
    {
        public bool IsSuccess { get; init; }
        public int Value { get; init; }
    }
}
