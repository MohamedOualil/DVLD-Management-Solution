using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;

namespace DVLD.WinForms.Features.Licenses;

public class LicensesService(IApiClient apiClient) : ILicensesService
{
    public Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request)
        => apiClient.PostAsync<int>("License", request);

    public Task<ApiResponse<LicenseDto>> GetLicenseAsync(int licenseId)
        => apiClient.GetAsync<LicenseDto>($"License/{licenseId}");

    public Task<ApiResponse<LicenseDto>> GetLicenseByLocalApplicationIdAsync(int localApplicationId)
        => apiClient.GetAsync<LicenseDto>($"License/by-local-application/{localApplicationId}");
}
