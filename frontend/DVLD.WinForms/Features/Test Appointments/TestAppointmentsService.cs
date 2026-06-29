using DVLD.WinForms.Common;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public class TestAppointmentsService(IApiClient apiClient) : ITestAppointmentsService
    {
        private readonly IApiClient _apiClient = apiClient;

        public async Task<ApiResponse<List<TestAppointmentsRespondDto>>> GetTestAppointmentsAsync(int localApplicationId, TestTypeEnum testType)
        {
            string endpoint = $"localapplications/{localApplicationId}/test-appointments?testTypeId={(int)testType}";

            return await _apiClient.GetAsync<List<TestAppointmentsRespondDto>>(endpoint);
        }
    }
}
