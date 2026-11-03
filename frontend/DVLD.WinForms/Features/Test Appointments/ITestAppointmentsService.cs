using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
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
        Task<ApiResponse<List<TestAppointmentsRespond>>> GetTestAppointmentsAsync(int localApplicationId, TestTypeEnum testType);
    }
}
