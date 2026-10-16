using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Test.ScheduleTest;
using DVLD.WinForms.Features.Test.RecordTestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test
{
    public class TestService(IApiClient apiClient) : ITestService
    {
        private readonly IApiClient _apiClient = apiClient;
        public Task<ApiResponse<RecordTestResultResponse>> RecordTestResultAsync(RecordTestResultRequest request) =>
            _apiClient.PostAsync<RecordTestResultResponse>("Test/Take", request);


        public async Task<ApiResponse<TestDetailsResponse>> GetTestDetailsAsync(int localApplicationId, int testTypeId)
        {
            string endpoint = $"Test/local-applications/{localApplicationId}/test-types/{testTypeId}/details";

            var response = await _apiClient.GetAsync<TestDetailsResponse>(endpoint);

            return response;
        }

        public Task<ApiResponse<int>> CreateAppointmentAsync(
                CreateTestAppointmentRequest request)
        {
            return _apiClient.PostAsync<int>(
                "Test/appointments",
                request);
        }
    }
}
