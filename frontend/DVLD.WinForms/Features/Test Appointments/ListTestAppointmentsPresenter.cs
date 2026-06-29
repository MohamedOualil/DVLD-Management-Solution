using DVLD.WinForms.Common;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public class ListTestAppointmentsPresenter : BasePresenter<IListTestAppointmentsView>
    {
        private readonly ITestAppointmentsService _testAppointmentsService;
        public ListTestAppointmentsPresenter(
            ITestAppointmentsService testAppointmentsService,
            IListTestAppointmentsView view, 
            AppSession session, 
            INavigationService navigationService) : base(view, session, navigationService)
        {
            _testAppointmentsService = testAppointmentsService;
            View.CreateAppointmentRequested += View_CreateAppointmentRequested;

        }

        private void View_CreateAppointmentRequested(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async Task LoadTestAppointementsAsync(int localApplicationId,TestTypeEnum testTypeEnum)
        {

            var appointements = await _testAppointmentsService.GetTestAppointmentsAsync(
                localApplicationId, 
                testTypeEnum);

            if (!appointements.IsSuccess)
            {
                View.DisplayMessage(appointements.Error!.AllMessages);
                return;
            }

            if (appointements.Data!.Count == 0)
            {
                View.DisplayMessage(appointements.Error!.AllMessages);
                return;
            }

            View.DisplayTestAppointments(appointements.Data);
        }
        public override void Dispose()
        {
            View.CreateAppointmentRequested -= View_CreateAppointmentRequested;
        }
    }
}
