using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.ApplicationInfo;
using DVLD.WinForms.Features.Persons.SelectPerson;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public enum enButtonStatus
    {
        NextStep = 1,
        Confiramtion = 2,
        Close = 3
    }
    public class NewLocalDrivingLicensePresenter : BasePresenter<INewLocalDrivingLicenseView>
    {
        private IServiceScope? _currentPageScope;
        private readonly IServiceProvider _serviceProvider;
        private readonly IApplicationsService _applicationsService;

        private int _selectedPersonId;
        private int _selectedLicenseClassId;
        private readonly string _CreatedBy;
        private Action? _cleanupOldEvents;

        private enButtonStatus _buttonStatus = enButtonStatus.NextStep;

        public event Action<int> SetApplicationId;
        
        public NewLocalDrivingLicensePresenter(
            IApplicationsService applicationsService,
            IServiceProvider serviceProvider,
            INewLocalDrivingLicenseView view, 
            AppSession session, 
            INavigationService navigationService) : base(view, session, navigationService)
        {
            _serviceProvider = serviceProvider;
            _applicationsService = applicationsService;
            _CreatedBy = session.Username;

            View.OnNextStepRequsted += View_OnNextStepRequsted;
        }

        private async void View_OnNextStepRequsted(object? sender, EventArgs e)
        {
            switch (_buttonStatus)
            {
                case enButtonStatus.NextStep:
                    _buttonStatus = enButtonStatus.Confiramtion;
                    await ApplicantInfoSecondStep();
                    break;
                case enButtonStatus.Confiramtion:
                    
                    await ConfiramtionApplicantInfo();
                    break;
                case enButtonStatus.Close:
                    await CloseApplicant();
                    break;
            }
            
        }

        private async Task ConfiramtionApplicantInfo()
        {
           
            if (_selectedLicenseClassId <= 0)
            {
                View.DisplayMessage("");
                return;
            }
            var request = new CreateLocalDrivingLicenseApplicationRequest
            {
                LicensesClassId = _selectedLicenseClassId,
                PersonId = _selectedPersonId,
            };
            var appId = await _applicationsService.CreateApplication(request);

            if (!appId.IsSuccess)
            {
                View.DisplayMessage(appId.Error!.AllMessages);
                return;
            }
            _buttonStatus = enButtonStatus.Close;

            SetApplicationId?.Invoke(appId.Data);

            View.DesignButton(_buttonStatus);
        }

        private async Task CloseApplicant()
        {
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }

        public void FirstStep()
        {
            DisplayTo<SelectPersonPresenter, ISelectPersonView>(presenter =>
            {
                presenter.PersonSelected += Presenter_PersonSelected;
                presenter.NoPersonSelected += Presenter_NoPersonSelected;

                _cleanupOldEvents = () =>  
                {
                    presenter.PersonSelected -= Presenter_PersonSelected;
                    presenter.NoPersonSelected -= Presenter_NoPersonSelected;
                };
            });


        }

        private void Presenter_NoPersonSelected()
        {
            _selectedPersonId = 0;
            View.IsEnableNextStepButton = false;
        }

      
        private async Task ApplicantInfoSecondStep()
        {
            View.DesignButton(_buttonStatus);
            View.IsEnableNextStepButton = false;


            ApiResponse<ApplicantSummaryDto>? result =
                await _applicationsService.GetApplicantSummary(
                    _selectedPersonId,
                    (int)ApplicationTypeEnum.NewLocalDrivingLicenseService);

            if (!result.IsSuccess)
            {
                View.DisplayMessage(result.Error!.AllMessages);
                return;
            }

            this.ClearOldScope();
            ApplicationInfoControl applicationInfo = new ApplicationInfoControl();


            SetApplicationId += (int id) =>
            {
                applicationInfo.ApplicationId = id.ToString();
            };

            applicationInfo.LoadApplicantData(result.Data!,_CreatedBy);


            applicationInfo.OnLicenseClassSelected += ApplicationInfo_OnLicenseClassSelected;
            _cleanupOldEvents = () =>
            {
                applicationInfo.OnLicenseClassSelected -= ApplicationInfo_OnLicenseClassSelected;

                SetApplicationId -= (int id) =>
                {
                    applicationInfo.ApplicationId = id.ToString();
                };
            };
            View.ShowChildView(applicationInfo);
        }

        

        private void ApplicationInfo_OnLicenseClassSelected(int obj)
        {
            _selectedLicenseClassId = obj;
            View.IsEnableNextStepButton = true;
        }

        private void Presenter_PersonSelected(int obj)
        {
            View.MessageLabel = false;
            _selectedPersonId = obj;
            View.IsEnableNextStepButton = true;

            if (_selectedPersonId <= 0)
            {
                View.DisplayMessage("Select The Person ");
                return;
            }
        }

        private void ClearOldScope()
        {
            _cleanupOldEvents?.Invoke();
            _cleanupOldEvents = null;

            _currentPageScope?.Dispose();
        }

        public override void Dispose()
        {
            ClearOldScope();
            View.OnNextStepRequsted += View_OnNextStepRequsted;
        }
        private void DisplayTo<TPresenter, TView>(Action<TPresenter> setup = null) where TPresenter
            : BasePresenter<TView> where TView : class
        {

            ClearOldScope();
            _currentPageScope = _serviceProvider.CreateScope();

            var presenter = _currentPageScope.ServiceProvider.GetRequiredService<TPresenter>();

            setup?.Invoke(presenter);

            View.ShowChildView(presenter.ViewInstance);
        }

    }
}
