using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication;
using DVLD.WinForms.Features.Applications.ApplicationInfo;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.WinForms.Features.Applications
{
    public class ApplicationsService(IApiClient apiClient) : IApplicationsService
    {
        private readonly IApiClient _apiClient = apiClient;



        public async Task<ApiResponse<PagedResultDto<LocalApplicationsDto>>> GetAllLocalApplicationsAsync(int pageNumber, int pageSize,string searchTerm,int statusId)
        {
            string endpoint = $"LocalDrivingLicenseApplication?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                endpoint += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }
            if (statusId > 0)
            {
                endpoint += $"&statusId={statusId}";
            }
            return await _apiClient.GetAsync<PagedResultDto<LocalApplicationsDto>>(endpoint);
        }

        public async Task<ApiResponse<ApplicationDetailDto>> GetApplicationDetails(int localId)
        {
            string endpoint = $"LocalDrivingLicenseApplication/{localId}";

            return await _apiClient.GetAsync<ApplicationDetailDto>(endpoint);
        }

        public async Task<ApiResponse<ApplicantSummaryDto>> GetApplicantSummary(int personId,int applicationTypeId)
        {
            string endpoint = $"LocalDrivingLicenseApplication/{personId}/type/{applicationTypeId}";

            return await _apiClient.GetAsync<ApplicantSummaryDto>(endpoint);
        }

        public Task<ApiResponse> UpdateDrivingLicenceApplication(int localApplicationId, LicenseClassEnum licenseType)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CancelApplication(int applicationId, int CancelBy)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<int>> CreateApplication(CreateLocalDrivingLicenseApplicationRequest request)
        {
            string endpoint = "LocalDrivingLicenseApplication";

            return await _apiClient.PostAsync<int>(endpoint, request);
        }

        public Task<ApiResponse> DeleteApplication(int localId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<TestResultsRoadmapDto>> GetTestResultsRoadmap(int localId)
        {
            string endpoint = $"Test/{localId}";

            return await _apiClient.GetAsync<TestResultsRoadmapDto>(endpoint);
        }
    }
}
