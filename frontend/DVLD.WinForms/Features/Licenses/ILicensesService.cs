using DVLD.WinForms.Common;

namespace DVLD.WinForms.Features.Licenses;

public interface ILicensesService
{
    Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request);
}
