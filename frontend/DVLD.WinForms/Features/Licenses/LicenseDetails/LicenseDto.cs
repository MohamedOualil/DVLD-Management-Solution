namespace DVLD.WinForms.Features.Licenses.LicenseDetails;

public sealed record LicenseDto
{
    public required string ClassName { get; init; }
    public required string FullName { get; init; }
    public int LicenseId { get; init; }
    public required string NationalNo { get; init; }
    public DateTime DateOfBirth { get; init; }
    public int Gender { get; init; }
    public string? ImagePath { get; init; }
    public DateTime IssueDate { get; init; }
    public DateTime ExpirationDate { get; init; }
    public int IssueReason { get; init; }
    public string? Notes { get; init; }
    public int DriverId { get; init; }
    public bool IsActive { get; init; }
    public bool IsDetained { get; init; }
}
