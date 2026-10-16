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
    public interface ITestService
    {
        Task<ApiResponse<RecordTestResultResponse>> RecordTestResultAsync(RecordTestResultRequest request);
        Task<ApiResponse<TestDetailsResponse>> GetTestDetailsAsync(int localApplicationId, int testTypeId);
        Task<ApiResponse<int>> CreateAppointmentAsync(
    CreateTestAppointmentRequest request);
    }
}
