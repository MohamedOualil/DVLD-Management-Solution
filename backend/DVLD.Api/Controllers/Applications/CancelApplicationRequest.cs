namespace DVLD.Api.Controllers.Applications;

public sealed record CancelApplicationRequest
{
    public int CancelBy { get; init; }
}
