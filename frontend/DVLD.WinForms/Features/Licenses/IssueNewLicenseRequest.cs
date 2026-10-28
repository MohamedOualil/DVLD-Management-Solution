namespace DVLD.WinForms.Features.Licenses;

public sealed record IssueNewLicenseRequest
{
    public int LocalApplicationId { get; init; }
    public int CreatedByUserId { get; init; }
    public string? Notes { get; init; }
}
