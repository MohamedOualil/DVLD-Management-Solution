using DVLD.Contracts.Common;
using DVLD.Contracts.Applications;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
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



        public async Task<ApiResponse<PagedList<GetAllLocalApplicationsResponse>>> GetAllLocalApplicationsAsync(int pageNumber, int pageSize,string searchTerm,int statusId)
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
            return await _apiClient.GetAsync<PagedList<GetAllLocalApplicationsResponse>>(endpoint);
        }

        public async Task<ApiResponse<LocalApplicationResponse>> GetApplicationDetails(int localId)
        {
            string endpoint = $"LocalDrivingLicenseApplication/{localId}";

            return await _apiClient.GetAsync<LocalApplicationResponse>(endpoint);
        }

        public async Task<ApiResponse<ApplicantSummaryRespond>> GetApplicantSummary(int personId,int applicationTypeId)
        {
            string endpoint = $"LocalDrivingLicenseApplication/{personId}/type/{applicationTypeId}";

            return await _apiClient.GetAsync<ApplicantSummaryRespond>(endpoint);
        }

        public async Task<ApiResponse> UpdateDrivingLicenceApplication(int localApplicationId, LicenseClassEnum licenseType)
        {
            return await _apiClient.PutAsync<object>(
                $"LocalDrivingLicenseApplication/{localApplicationId}",
                new UpdateLocalDrivingLicenseApplicationRequest { LicenseClass = licenseType });
        }

        public async Task<ApiResponse> CancelApplication(int applicationId, int CancelBy)
        {
            return await _apiClient.PostAsync<object>(
                $"Application/{applicationId}/cancel",
                new CancelApplicationRequest { CancelBy = CancelBy });
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

        public async Task<ApiResponse<TestRoadmapResponse>> GetTestResultsRoadmap(int localId)
        {
            string endpoint = $"Test/{localId}";

            return await _apiClient.GetAsync<TestRoadmapResponse>(endpoint);
        }
    }
}
