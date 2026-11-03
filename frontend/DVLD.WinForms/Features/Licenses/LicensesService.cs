using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;

namespace DVLD.WinForms.Features.Licenses;

public class LicensesService(IApiClient apiClient) : ILicensesService
{
    public Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request)
        => apiClient.PostAsync<int>("License", request);

    public Task<ApiResponse<GetLicenseResponse>> GetLicenseAsync(int licenseId)
        => apiClient.GetAsync<GetLicenseResponse>($"License/{licenseId}");

    public Task<ApiResponse<GetLicenseResponse>> GetLicenseByLocalApplicationIdAsync(int localApplicationId)
        => apiClient.GetAsync<GetLicenseResponse>($"License/by-local-application/{localApplicationId}");
}
