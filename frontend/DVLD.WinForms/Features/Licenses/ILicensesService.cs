#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Licenses;

public sealed class InternationalLicenseListItemDto
{
    public int InternationalLicenseId { get; set; }
    public int ApplicationId { get; set; }
    public int DriverId { get; set; }
    public int LocalLicenseId { get; set; }
    public int PersonId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string NationalNo { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }
}

public sealed class DetainedLicenseListItemDto
{
    public int DetainId { get; set; }
    public int LicenseId { get; set; }
    public int PersonId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string NationalNo { get; set; } = string.Empty;
    public DateTime DetainDate { get; set; }
    public decimal FineFees { get; set; }
    public bool IsReleased { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? ReleaseApplicationId { get; set; }
}

public interface ILicensesService
{
    Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request);
    Task<ApiResponse<GetLicenseResponse>> GetLicenseAsync(int licenseId);
    Task<ApiResponse<GetLicenseResponse>> GetLicenseByLocalApplicationIdAsync(int localApplicationId);
    Task<ApiResponse<int>> RenewLicenseAsync(int licenseId, string? notes);
    Task<ApiResponse<int>> ReplaceLicenseAsync(int licenseId, ReplacmentTypeEnum replacementType, string? notes);
    Task<ApiResponse<int>> DetainLicenseAsync(int licenseId, decimal fineFees, string? notes);
    Task<ApiResponse<int>> ReleaseDetainedLicenseAsync(int licenseId, string? notes);
    Task<ApiResponse<int>> IssueInternationalLicenseAsync(int localLicenseId);
    Task<ApiResponse<PagedList<GetLocalDrivingLicenseHistoryResponse>>> GetLocalLicenseHistoryAsync(int personId, int pageNumber, int pageSize);
    Task<ApiResponse<PagedList<GetInternationalDrivingLicenseHistoryResponse>>> GetInternationalLicenseHistoryAsync(int personId, int pageNumber, int pageSize);
    Task<ApiResponse<GetInternationalLicenseResponse>> GetInternationalLicenseAsync(int internationalLicenseId);
    Task<ApiResponse<PagedList<InternationalLicenseListItemDto>>> GetAllInternationalLicensesAsync(int pageNumber, int pageSize, string? searchTerm, int statusFilter);
    Task<ApiResponse<PagedList<DetainedLicenseListItemDto>>> GetAllDetainedLicensesAsync(int pageNumber, int pageSize, string? searchTerm, int statusFilter);
}
