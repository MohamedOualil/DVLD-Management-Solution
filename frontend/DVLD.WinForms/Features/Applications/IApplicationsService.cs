using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsService
    {
        Task<ApiResponse<PagedResultDto<LocalApplicationsDto>>> GetAllLocalApplicationsAsync(
            int pageNumber, int pageSize, string searchTerm, int statusId);

        Task<ApiResponse<ApplicationDetailDto>> GetApplicationDetails(int localId);
        Task<ApiResponse> CancelApplication(int applicationId,int CancelBy);
        Task<ApiResponse> UpdateDrivingLicenceApplication(int localApplicationId,LicenseClassEnum licenseType);
        Task<ApiResponse> DeleteApplication(int localId); 

        Task<ApiResponse<TestResultsRoadmapDto>> GetTestResultsRoadmap(int localId);
    }
}
