using DVLD.Contracts.Common;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsService
    {
        Task<ApiResponse<PagedList<GetAllLocalApplicationsResponse>>> GetAllLocalApplicationsAsync(
            int pageNumber, int pageSize, string searchTerm, int statusId);

        Task<ApiResponse<LocalApplicationResponse>> GetApplicationDetails(int localId);
        Task<ApiResponse> CancelApplication(int applicationId, int CancelBy);
        Task<ApiResponse> UpdateDrivingLicenceApplication(int localApplicationId, LicenseClassEnum licenseType);
        Task<ApiResponse> DeleteApplication(int localId);

        Task<ApiResponse<TestRoadmapResponse>> GetTestResultsRoadmap(int localId);
        Task<ApiResponse<ApplicantSummaryRespond>> GetApplicantSummary(int personId, int applicationTypeId);
        Task<ApiResponse<int>> CreateApplication(CreateLocalDrivingLicenseApplicationRequest request);
    }
}
