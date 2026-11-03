using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
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

        private enButtonStatus _step = enButtonStatus.PersonInfoStep;

        public event Action<int> SetApplicationId;

        private bool _busy;
        private bool _disposed;
        private bool _saveUncertain;

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
            if (_disposed || _busy)
                return;

            try
            {
                if (_saveUncertain ||
                    _step != enButtonStatus.ApplicantInfoStep)
                {
                    ReturnToApplicationsList();
                    return;
                }

                LoadPersonInfoStep();
            }
            catch (Exception)
            {
                if (!_disposed)
                    View.DisplayMessage(
                        "Unable to return to the previous page.");
            }

        }

        private async void View_OnNextStepRequsted(object? sender, EventArgs e)
        {
            if (_disposed || _busy)
                return;

            bool saving = _step == enButtonStatus.ApplicantInfoStep;

            try
            {
                if (_step == enButtonStatus.CreateApplication)
                {
                    ReturnToApplicationsList();
                    return;
                }

                if (_saveUncertain)
                    return;

                _busy = true;

                View.SetBusy(true);
                View.MessageLabel = false;

                switch (_step)
                {
                    case enButtonStatus.PersonInfoStep:
                        await LoadApplicantInfoStepAsync();
                        break;

                    case enButtonStatus.ApplicantInfoStep:
                        await CreateApplicationAsync();
                        break;
                }
            }
            catch (Exception)
            {
                if (_disposed)
                    return;

                if (saving)
                    ShowUncertainSave();
                else
                    View.DisplayMessage(
                        "Unable to load applicant information. Please try again.");
            }
            finally
            {
                _busy = false;

                if (!_disposed)
                {
                    View.SetBusy(false);
                    RefreshNextButton();
                }
            }

        }

        private async Task CreateApplicationAsync()
        {
            int personId = _selectedPersonId.GetValueOrDefault();
            int classId = _selectedLicenseClassId.GetValueOrDefault();

            if (personId <= 0)
            {
                View.DisplayMessage("Select a valid applicant.");
                return;
            }

            if (!Enum.IsDefined(typeof(LicenseClassEnum), classId))
            {
                View.DisplayMessage("Select a valid licence class.");
                return;
            }

            var request = new CreateLocalDrivingLicenseApplicationRequest
            {
                PersonId = personId,
                LicensesClassId = classId
            };

            var response =
                await _applicationsService.CreateApplication(request);

            if (_disposed)
                return;

            if (!response.IsSuccess)
            {
                // These failures may leave the save outcome unknown.
                int status = response.Error?.Status ?? 0;

                if (status <= 0 || status == 408 || status >= 500)
                {
                    ShowUncertainSave();
                    return;
                }

                View.DisplayMessage(GetErrorMessage(
                    response,
                    "Unable to create the application."));

                return;
            }

            if (response.Data <= 0)
            {
                ShowUncertainSave();
                return;
            }

            // Update both presenter state and UI.
            SetStep(enButtonStatus.CreateApplication);
            View.ShowCreatedApplication(response.Data);
        }

        private void ReturnToApplicationsList()
        {
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }

        public void LoadPersonInfoStep()
        {

            if (_disposed || _busy)
                return;

            ClearOldScope();

            _selectedPersonId = null;
            _selectedLicenseClassId = null;
            _saveUncertain = false;

            _currentPageScope = _serviceProvider.CreateScope();

            try
            {
                var presenter = _currentPageScope.ServiceProvider
                    .GetRequiredService<SelectPersonPresenter>();

                presenter.PersonSelected += Presenter_PersonSelected;
                presenter.NoPersonSelected += Presenter_NoPersonSelected;

                _cleanupOldEvents = () =>
                {
                    presenter.PersonSelected -= Presenter_PersonSelected;
                    presenter.NoPersonSelected -= Presenter_NoPersonSelected;
                };

                View.ShowChildView(presenter.ViewInstance);
                SetStep(enButtonStatus.PersonInfoStep);
            }
            catch
            {
                ClearOldScope();
                throw;
            }


        }

        private void Presenter_NoPersonSelected()
        {
            if (_disposed || _busy)
                return;

            _selectedPersonId = null;
            _selectedLicenseClassId = null;

            RefreshNextButton();

        }

        private async Task LoadApplicantInfoStepAsync()
        {
            int personId = _selectedPersonId.GetValueOrDefault();

            if (personId <= 0)
            {
                View.DisplayMessage("Select an applicant first.");
                return;
            }

            var response = await _applicationsService.GetApplicantSummary(
                personId,
                (int)ApplicationTypeEnum.NewLocalDrivingLicenseService);

            if (_disposed)
                return;

            if (!response.IsSuccess || response.Data is null)
            {
                View.DisplayMessage(GetErrorMessage(
                    response,
                    "Unable to load applicant information."));

                return;
            }

            if (response.Data.PersonId != personId)
            {
                View.DisplayMessage(
                    "The returned information does not match the applicant.");
                return;
            }

            var applicationInfo = new ApplicationInfoControl();

            try
            {
                applicationInfo.LoadApplicantData(
                    response.Data,
                    _session.Username);

                View.ShowChildView(applicationInfo);
            }
            catch
            {
                applicationInfo.Dispose();
                throw;
            }

            ClearOldScope();

            applicationInfo.OnLicenseClassSelected +=
                ApplicationInfo_OnLicenseClassSelected;

            _cleanupOldEvents = () =>
            {
                applicationInfo.OnLicenseClassSelected -=
                    ApplicationInfo_OnLicenseClassSelected;
            };

            _selectedLicenseClassId = null;

            // Move to step 2 only after loading and displaying succeeded.
            SetStep(enButtonStatus.ApplicantInfoStep);
        }



        private void ApplicationInfo_OnLicenseClassSelected(int classId)
        {

            if (_disposed || _busy ||
               _step != enButtonStatus.ApplicantInfoStep)
            {
                return;
            }

            _selectedLicenseClassId =
                Enum.IsDefined(typeof(LicenseClassEnum), classId)
                    ? classId
                    : null;

            View.MessageLabel = false;
            RefreshNextButton();
        }

        private void Presenter_PersonSelected(int personId)
        {

            if (_disposed || _busy ||
                _step != enButtonStatus.PersonInfoStep)
            {
                return;
            }

            _selectedPersonId = personId > 0 ? personId : null;
            _selectedLicenseClassId = null;

            View.MessageLabel = false;
            RefreshNextButton();


        }

        private void ClearOldScope()
        {
            _cleanupOldEvents?.Invoke();
            _cleanupOldEvents = null;

            _currentPageScope?.Dispose();
            _currentPageScope = null;
        }

        public override void Dispose()
        {

            if (_disposed)
                return;

            _disposed = true;

            View.OnNextStepRequsted -= View_OnNextStepRequsted;
            View.OnGoBackRequested -= View_OnGoBackRequested;

            ClearOldScope();
        }


        private void SetStep(enButtonStatus step)
        {
            _step = step;

            View.MessageLabel = false;
            View.UpdateButtonsForState(step);

            RefreshNextButton();
        }

        private void RefreshNextButton()
        {
            View.IsEnableNextStepButton = _step switch
            {
                enButtonStatus.PersonInfoStep =>
                    _selectedPersonId is > 0,

                enButtonStatus.ApplicantInfoStep =>
                    _selectedPersonId is > 0 &&
                    _selectedLicenseClassId is > 0 &&
                    !_saveUncertain,

                enButtonStatus.CreateApplication => true,

                _ => false
            };
        }

        private void ShowUncertainSave()
        {
            _saveUncertain = true;

            View.DisplayMessage(
                "Unable to confirm whether the application was saved. " +
                "Use Back to return to the list and check before trying again.");
        }

        private static string GetErrorMessage(
            ApiResponse response,
            string fallback)
        {
            string? message = response.Error?.AllMessages;

            return string.IsNullOrWhiteSpace(message)
                ? fallback
                : message;
        }

    }
}
