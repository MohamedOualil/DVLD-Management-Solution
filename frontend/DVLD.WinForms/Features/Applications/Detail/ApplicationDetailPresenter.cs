using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.Detail;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public class ApplicationDetailPresenter : BasePresenter<IApplicationDetailView>
    {
        private readonly IApplicationsService _applicationsService;
        private readonly IPesronService _pesronService;
        private readonly ILicensesService _licensesService;

        private bool _disposed;
        private bool _loading;
        private bool _saving;

        private int _localApplicationId;
        private int _applicationId;

        public ApplicationDetailPresenter(IApplicationDetailView view,
            AppSession appSession,
            INavigationService navigationService,
            IApplicationsService applicationsService,
            IPesronService pesronService,
            ILicensesService licensesService)
            : base(view, appSession, navigationService)
        {
            _applicationsService = applicationsService;
            _pesronService = pesronService;
            _licensesService = licensesService;

            View.CanacleApplicationRequest += View_CanacleApplicationRequest;
            View.SaveEditApplicationRequest += View_SaveEditApplicationRequest;
            View.ShowLicenses += View_ShowLicenses;
            View.BackToApplications += View_BackToApplications;

        }

        private void View_BackToApplications(object? sender, EventArgs e)
        {
            if (!_disposed && !_saving && !_loading)
                _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }

        private async void View_ShowLicenses(object? sender, EventArgs e)
        {
            if (_disposed || _loading || _saving || _localApplicationId <= 0)
                return;

            _loading = true;
            try
            {

                View.SetBusy(true);

                var response = await _licensesService.GetLicenseByLocalApplicationIdAsync(_localApplicationId);
                if (_disposed)
                    return;

                if (!response.IsSuccess || response.Data is null)
                {
                    View.DisplayMessage(
                            GetErrorMessage(response, "Unable to load licence details."));
                    return;
                }

                _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(response.Data));
            }
            catch (Exception)
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load licence details. Please try again.");
            }
            finally
            {
                _loading = false;
                if (!_disposed)
                    View.SetBusy(false);
            }

            
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

            if (_disposed || _loading || _saving || _localApplicationId <= 0)
                return;

            int classId = View.ApplicationLicenseClass;

            if (!Enum.IsDefined(typeof(LicenseClassEnum), classId))
            {
                View.DisplayMessage("Select a valid licence class.");
                return;
            }

            _saving = true;

            try
            {
                View.SetBusy(true);

                ApiResponse result = await _applicationsService.UpdateDrivingLicenceApplication(
                    _localApplicationId,
                    (LicenseClassEnum)View.ApplicationLicenseClass);

                if (_disposed) return;

                if (!result.IsSuccess)
                {
                    View.DisplayMessage(
                        GetErrorMessage(result, "Unable to save changes."));
                    return;
                }

                View.ControlMode(StatusMode.ViewMode);

 
            }
            catch (Exception)
            {
                if (!_disposed)
                {
                    View.DisplayMessage(
                        "Unable to confirm whether the changes were saved. " +
                        "Reload the application before trying again.");
                }
            }

            finally
            {
                _saving = false;

                if (!_disposed)
                    View.SetBusy(false);
            }


        }

        private async Task OnCancelApplication()
        {
            if (_disposed || _loading || _saving || _applicationId <= 0)
                return;

            _saving = true;

            try
            {
                View.SetBusy(true);
                ApiResponse result =
                    await _applicationsService.CancelApplication(_applicationId, _session.UserId);

                if (_disposed) return;

                if (!result.IsSuccess)
                {
                    View.DisplayMessage(
                        GetErrorMessage(result, "Unable to cancel the application."));
                    return;
                }

                View.ApplicationStatus = ApplicationStatusEnum.Cancelled;
                View.ControlMode(StatusMode.ViewMode);
            }

            catch (Exception)
            {
                if (!_disposed)
                {
                    View.DisplayMessage(
                        "Unable to confirm whether the application was cancelled. " +
                        "Reload it before trying again.");
                }
            }

            finally
            {
                _saving = false;

                if (!_disposed)
                    View.SetBusy(false);
            }





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

        public async Task LoadApplicationDetails(int localApplicationId, StatusMode mode)
        {


            if (_disposed || _loading || _saving)
                return;

            _loading = true;

            try
            {
                View.SetBusy(true);
                View.ControlMode(mode);

                await ApplicationDetailInitialized(localApplicationId);
            }
            finally
            {
                _loading = false;

                if (!_disposed)
                    View.SetBusy(false);
            }
        }

        private async Task ApplicationDetailInitialized(int localApplicationId)
        {
            if (_disposed || _saving ) return;

            _localApplicationId = 0;
            _applicationId = 0;

            if (localApplicationId <= 0)
            {
                View.DisplayMessage("Select a valid local application.");
                return;
            }

            try
            {
                var applicationDetailTask =
                     _applicationsService.GetApplicationDetails(localApplicationId);

                var testRoadMapTask =
                    _applicationsService.GetTestResultsRoadmap(localApplicationId);

                await Task.WhenAll(applicationDetailTask, testRoadMapTask);

                if (_disposed) return;

                var testsResponse = testRoadMapTask.Result;
                var applicationResponse = applicationDetailTask.Result;

                if (!applicationResponse.IsSuccess ||
                                        applicationResponse.Data is null)
                {
                    ShowLoadError(GetErrorMessage(
                        applicationResponse,
                        "Unable to load application details."));
                    return;
                }

                if (!testsResponse.IsSuccess || testsResponse.Data is null)
                {
                    ShowLoadError(GetErrorMessage(
                        testsResponse,
                        "Unable to load test results."));
                    return;
                }

                var application = applicationResponse.Data;
                var tests = testsResponse.Data;

                if (application.LocalId != localApplicationId ||
            tests.LocalApplicationId != localApplicationId)
                {
                    ShowLoadError(
                        "The returned details do not match the selected application.");
                    return;
                }

                if (application.ApplicationId <= 0 || application.PersonId <= 0)
                {
                    ShowLoadError("The application contains invalid information.");
                    return;
                }

                if (!Enum.TryParse<ApplicationStatusEnum>( application.Status,
                ignoreCase: true,
                out var status) ||
                        !Enum.IsDefined(typeof(ApplicationStatusEnum), status))
                {
                    ShowLoadError("The application has an unknown status.");
                    return;
                }

                if (!Enum.IsDefined(
                typeof(LicenseClassEnum),
                application.LicenseClassId))
                {
                    ShowLoadError("The application has an unknown licence class.");
                    return;
                }

                var personResponse =
                            await _pesronService.GetPerson(application.PersonId);

                if (_disposed)
                    return;


                if (!personResponse.IsSuccess || personResponse.Data is null)
                {
                    ShowLoadError(GetErrorMessage(
                        personResponse,
                        "Unable to load applicant information."));
                    return;
                }

                if (personResponse.Data.PersonId != application.PersonId)
                {
                    ShowLoadError(
                        "The returned person does not match the applicant.");
                    return;
                }


                // All required data is available. Update the screen.
                View.ApplicationStatus = status;
                View.StatusDate =
                    application.LastStatusDate.ToString("dd/MM/yyyy");
                View.CreateBy = application.CreatedBy;
                View.ApplicationId = application.ApplicationId.ToString();
                View.LocalApplicationId = application.LocalId.ToString();
                View.ApplicationType = application.ApplicationType;
                View.ApplicationLicenseClass = application.LicenseClassId;
                View.Fees = application.PaidFees.ToString("C");

                View.LoadPersonInfo(personResponse.Data);
                View.LoadTestRoadmap(tests);



                if (status != ApplicationStatusEnum.New)
                    View.ControlMode(StatusMode.ViewMode);

                _localApplicationId = application.LocalId;
                _applicationId = application.ApplicationId;
            }

            catch (Exception)
            {

                ShowLoadError("Unable to load application information. Please try again.");
            }

        }

        private void ShowLoadError(string message)
        {
            if (!_disposed)
                View.DisplayMessage(message);
        }

        public override void Dispose()
        {
            _disposed = true;
            View.CanacleApplicationRequest -= View_CanacleApplicationRequest;
            View.SaveEditApplicationRequest -= View_SaveEditApplicationRequest;
            View.ShowLicenses -= View_ShowLicenses;
            View.BackToApplications -= View_BackToApplications;
        }
    }
}
