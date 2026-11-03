namespace DVLD.Contracts.Applications;

public sealed record CancelApplicationRequest
{
    public int CancelBy { get; init; }
}
