using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;

namespace DVLD.WinForms.Features.Licenses;

public interface ILicensesService
{
    Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request);
    Task<ApiResponse<LicenseDto>> GetLicenseAsync(int licenseId);
    Task<ApiResponse<LicenseDto>> GetLicenseByLocalApplicationIdAsync(int localApplicationId);
}
