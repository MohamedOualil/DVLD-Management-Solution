using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.Detail;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public class ApplicationDetailPresenter : BasePresenter<IApplicationDetailView>
    {
        private readonly IApplicationsService _applicationsService;
        private readonly IPesronService _pesronService;
        public ApplicationDetailPresenter(IApplicationDetailView view,
            AppSession appSession,
            INavigationService navigationService,
            IApplicationsService applicationsService,
            IPesronService pesronService)
            : base(view, appSession, navigationService)
        {
            _applicationsService = applicationsService;
            _pesronService = pesronService;

            View.CanacleApplicationRequest += View_CanacleApplicationRequest;
            View.SaveEditApplicationRequest += View_SaveEditApplicationRequest;

        }

        private async void View_SaveEditApplicationRequest(object? sender, EventArgs e)
        {
            await OnSaveEditApplication();
        }


        private async void View_CanacleApplicationRequest(object? sender, EventArgs e)
        {
            await OnCancelApplication();
        }

        private async Task OnSaveEditApplication()
        {
            int localId = int.Parse(View.LocalApplicationId);
            ApiResponse result = await _applicationsService.UpdateDrivingLicenceApplication(
                localId,
                (LicenseClassEnum)View.ApplicationLicenseClass);

            if (result.IsSuccess)
            {
                View.ControlMode(StatusMode.ViewMode);
            }
            
        }

        private async Task OnCancelApplication()
        {
            int applicationId = int.Parse(View.ApplicationId);
            ApiResponse result = 
                await _applicationsService.CancelApplication(applicationId, _session.UserId);

            if (result.IsSuccess)
            {
                View.ApplicationStatus = ApplicationStatusEnum.Cancelled;
            }
        }

        public async void LoadApplicationDetails(int LocalId,StatusMode statusMode)
        {
            View.ControlMode(statusMode);
            await ApplicationDetailInitialized(LocalId);
        }

        private async Task ApplicationDetailInitialized(int localId)
        {
            ApiResponse<ApplicationDetailDto>? applicationDetail = await 
                     _applicationsService.GetApplicationDetails(localId);

            
            if (!applicationDetail.IsSuccess)
            {
                return;
            }
            var applicationData = applicationDetail.Data;


            View.ApplicationStatus = Enum.Parse<ApplicationStatusEnum>(applicationData.Status);
            View.StatusDate = applicationData.LastStatusDate.ToString("dd/MM/yyyy");
            View.CreateBy = applicationData.CreatedBy;
            View.ApplicationId = applicationData.ApplicationId.ToString();
            View.ApplicationType = applicationData.ApplicationName;
            View.ApplicationLicenseClass = applicationData.LicenseClassId;
            View.LocalApplicationId = applicationData.LocalId.ToString();
            View.Fees = applicationData.PaidFees.ToString("C");
   
            ApiResponse<PersonDto>? person = await _pesronService.GetPerson(applicationDetail.Data!.PersonId);

            if (!person.IsSuccess)
            {
                return;
            }

            View.LoadPersonInfo(person.Data!);


        }

        public override void Dispose()
        {
            View.CanacleApplicationRequest -= View_CanacleApplicationRequest;
            View.SaveEditApplicationRequest -= View_SaveEditApplicationRequest;
        }
    }
}
