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
        PersonInfoStep = 1,
        ApplicantInfoStep = 2,
        CreateApplication = 3
    }
    public class NewLocalDrivingLicensePresenter : BasePresenter<INewLocalDrivingLicenseView>
    {
        private IServiceScope? _currentPageScope;
        private readonly IServiceProvider _serviceProvider;
        private readonly IApplicationsService _applicationsService;

        private int? _selectedPersonId = null;
        private int? _selectedLicenseClassId = null;
        private readonly string _CreatedBy;
        private Action? _cleanupOldEvents;

        private enButtonStatus _buttonStatus = enButtonStatus.PersonInfoStep;

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
            View.OnGoBackRequested += View_OnGoBackRequested;
        }

        private void View_OnGoBackRequested(object? sender, EventArgs e)
        {
            switch (_buttonStatus)
            {
                case enButtonStatus.PersonInfoStep:
                    ReturnToApplicationsList();
                    break;
                case enButtonStatus.ApplicantInfoStep:
                    LoadPersonInfoStep();
                    ResetUiDisplay(enButtonStatus.PersonInfoStep);
                    break;
                case enButtonStatus.CreateApplication:
                    break;
            }
        }

        private async void View_OnNextStepRequsted(object? sender, EventArgs e)
        {

            try
            {
                switch (_buttonStatus)
                {
                    case enButtonStatus.PersonInfoStep:

                        await LoadApplicantInfoStep();
                        break;
                    case enButtonStatus.ApplicantInfoStep:
                        await CreateLocalDrivingLicenseApplication();
                        break;
                    case enButtonStatus.CreateApplication:
                        ReturnToApplicationsList();
                        break;
                }
            }
            catch (Exception ex)
            {
                View.DisplayMessage($"Error: {ex.Message}");
            }

        }

        private async Task CreateLocalDrivingLicenseApplication()
        {

            if (!_selectedLicenseClassId.HasValue)
            {
                View.DisplayMessage("Please select a License Class.");
                return;
            }
            var request = new CreateLocalDrivingLicenseApplicationRequest
            {
                LicensesClassId = _selectedLicenseClassId.Value,
                PersonId = _selectedPersonId.Value,
            };
            var appId = await _applicationsService.CreateApplication(request);

            if (!appId.IsSuccess)
            {
                View.DisplayMessage(appId.Error!.AllMessages);
                return;
            }

            View.UpdateButtonsForState(enButtonStatus.CreateApplication);
            SetApplicationId?.Invoke(appId.Data);

        }

        private void ReturnToApplicationsList()
        {
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }

        public void LoadPersonInfoStep()
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
            _selectedPersonId = null;
            _selectedLicenseClassId = null;

            View.IsEnableNextStepButton = false;
        }

        private void ResetUiDisplay(enButtonStatus newStatus)
        {
            _buttonStatus = newStatus;
            View.UpdateButtonsForState(_buttonStatus);
            View.IsEnableNextStepButton = false;
        }
      
        private async Task LoadApplicantInfoStep()
        {

            ResetUiDisplay(enButtonStatus.ApplicantInfoStep);

            ApiResponse<ApplicantSummaryDto>? result =
                await _applicationsService.GetApplicantSummary(
                    _selectedPersonId.Value,
                    (int)ApplicationTypeEnum.NewLocalDrivingLicenseService);

            if (!result.IsSuccess)
            {
                View.DisplayMessage(result.Error!.AllMessages);
                return;
            }

            this.ClearOldScope();
            ApplicationInfoControl applicationInfo = new ApplicationInfoControl();

            Action<int> updateApplicationIdAction = (int id) =>
            {
                applicationInfo.ApplicationId = id.ToString();
            };

            SetApplicationId += updateApplicationIdAction;
            applicationInfo.LoadApplicantData(result.Data!,_CreatedBy);


            applicationInfo.OnLicenseClassSelected += ApplicationInfo_OnLicenseClassSelected;
            _cleanupOldEvents = () =>
            {
                applicationInfo.OnLicenseClassSelected -= ApplicationInfo_OnLicenseClassSelected;

                SetApplicationId -= updateApplicationIdAction;
            };
            View.ShowChildView(applicationInfo);
        }

        

        private void ApplicationInfo_OnLicenseClassSelected(int obj)
        {
            _selectedLicenseClassId = obj;
            View.IsEnableNextStepButton = true;
        }

        private void Presenter_PersonSelected(int newPersonId)
        {
            View.MessageLabel = false;

            if (_selectedPersonId != newPersonId)
            {
                _selectedLicenseClassId = null;
            }

            _selectedPersonId = newPersonId;

            View.IsEnableNextStepButton = true;

            if (!_selectedPersonId.HasValue)
            {
                View.DisplayMessage("Select The Person");
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
            View.OnNextStepRequsted -= View_OnNextStepRequsted;
            View.OnGoBackRequested -= View_OnGoBackRequested;
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
