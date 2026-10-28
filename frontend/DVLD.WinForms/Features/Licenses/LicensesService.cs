using DVLD.WinForms.Common;

namespace DVLD.WinForms.Features.Licenses;

public class LicensesService(IApiClient apiClient) : ILicensesService
{
    public Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request)
        => apiClient.PostAsync<int>("License", request);
}
