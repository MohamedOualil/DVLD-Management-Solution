using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;

namespace DVLD.WinForms.Features.Licenses;

public interface ILicensesService
{
    Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request);
    Task<ApiResponse<GetLicenseResponse>> GetLicenseAsync(int licenseId);
    Task<ApiResponse<GetLicenseResponse>> GetLicenseByLocalApplicationIdAsync(int localApplicationId);
}
