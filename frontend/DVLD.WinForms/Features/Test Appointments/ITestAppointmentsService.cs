using DVLD.WinForms.Common;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public interface ITestAppointmentsService
    {
        Task<ApiResponse<List<TestAppointmentsRespondDto>>> GetTestAppointmentsAsync(int localApplicationId, TestTypeEnum testType);
    }
}
