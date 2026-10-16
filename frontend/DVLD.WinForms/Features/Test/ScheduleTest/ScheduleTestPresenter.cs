using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Test_Appointments;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public class ScheduleTestPresenter : BasePresenter<IScheduleTestView>
    {
        private readonly IApplicationsService _applicationsService;
        private readonly ITestService _testService;

        private int _localApplicationId;
        private TestTypeEnum _testType;
        private bool _isReady;
        private bool _isSaving;
        private bool _saved;

        public ScheduleTestPresenter(
            IApplicationsService applicationsService, 
            ITestService testService,
            IScheduleTestView view, 
            AppSession session, 
            INavigationService navigationService) : base(view, session, navigationService)
        {
            _applicationsService = applicationsService;
            _testService = testService;

            View.SaveRequested += OnSaveRequested;
            View.CancelRequested += OnCancelRequested;
        }



        public async Task LoadTestInfoAsync(int localApplicationId, TestTypeEnum testTypeEnum)
        {
            _localApplicationId = localApplicationId;
            _testType = testTypeEnum;
            _isReady = false;
            _saved = false;

            try
            {
                var applicationDetailTask =
                     _applicationsService.GetApplicationDetails(localApplicationId);

                var testInfoTask = _testService.GetTestDetailsAsync(localApplicationId, (int)testTypeEnum);

                await Task.WhenAll(applicationDetailTask, testInfoTask);

                var testInfo = testInfoTask.Result;
                var applicationDetail = applicationDetailTask.Result;


                if (!applicationDetail.IsSuccess)
                {
                    View.DisplayMessage(
                applicationDetail.Error?.AllMessages
                ?? "Could not load the application details.");
                    return;
                }

                if (!testInfo.IsSuccess)
                {
                    View.DisplayMessage(
                testInfo.Error?.AllMessages
                ?? "Could not load the test information.");
                    return;
                }

                var application = applicationDetail.Data;
                var test = testInfo.Data;

                if (application is null || test is null)
                {
                    View.DisplayMessage(
                        "The server returned incomplete information.");
                    return;
                }

                var scheduleTestDto = new SchelduleTestDto
                {
                    FullName = application.FullName,
                    DateOfBirth = application.DateOfBirth,
                    Age = application.Age,
                    LocalId = localApplicationId,
                    NationalNo = application.NationalNo,
                    ApplicationType = application.ApplicationType,
                    LicenseClassName = application.LicenseClassName,
                    PersonImagePath = application.PersonImagePath,
                    TestFees = test.TestFees,
                    TestTypeId = test.TestTypeId,
                    TrialsCount = test.TrialsCount,
                    TestName = TestName(testTypeEnum)
                };

                View.DisplayTestInfo(scheduleTestDto);



                _isReady = true;
            }

            catch (HttpRequestException)
            {
                View.DisplayMessage(
                    "Could not connect to the API. Please try again.");
            }
            catch (TaskCanceledException)
            {
                View.DisplayMessage(
                    "Loading timed out. Please try again.");
            }
            catch (Exception)
            {
                View.DisplayMessage(
                    "An unexpected error occurred while loading test information.");
            }

            
        }

        private string TestName(TestTypeEnum testTypeEnum)
        {
            switch (testTypeEnum)
            {
                case TestTypeEnum.VisionTest:
                    return "Vision Test";
                case TestTypeEnum.StreetTest:
                    return "Street Test";
                case TestTypeEnum.WrittenTest:
                    return "Written Test";
                default:
                    return "Unkonw Test";
            }
        }

        private async void OnSaveRequested(object? sender, EventArgs e)
        {
            if (_isSaving || _saved)
                return;

            if (!_isReady)
            {
                View.DisplayMessage("Load the test information before saving.");
                return;
            }

            DateTime appointmentDate = View.AppointmentDate;

            if (appointmentDate <= DateTime.UtcNow)
            {
                View.DisplayMessage("Select a future appointment date and time.");
                return;
            }

            if (!_session.IsLoggedIn || _session.UserId <= 0)
            {
                View.DisplayMessage("Please log in before scheduling a test.");
                return;
            }

            _isSaving = true;
            View.SetSaving(true);

            try
            {
                var request = new CreateTestAppointmentRequest
                {
                    LocalApplicationId = _localApplicationId,
                    CreatedById = _session.UserId,
                    AppointmentDate = appointmentDate,
                    TestType = (int)_testType
                };

                var response = await _testService.CreateAppointmentAsync(request);

                if (!response.IsSuccess)
                {
                    View.DisplayMessage(
                        response.Error?.AllMessages
                        ?? "Could not save the appointment.");
                    return;
                }

                _saved = true;

                View.DisplayMessage(
                    $"Appointment #{response.Data} saved successfully.");
            }
            catch (HttpRequestException)
            {
                View.DisplayMessage("Could not connect to the API.");
            }
            catch (TaskCanceledException)
            {
                View.DisplayMessage(
                    "The request timed out. Refresh the appointments list " +
                    "before trying again to check whether it was saved.");
            }
            catch (Exception)
            {
                View.DisplayMessage(
                    "An unexpected error occurred. Refresh the appointments " +
                    "list before trying again.");
            }
            finally
            {
                _isSaving = false;
                View.SetSaving(false);
            }

            if (_saved)
            {
                ReturnToAppointments();
            }
        }

        private void OnCancelRequested(object? sender, EventArgs e)
        {
            if (_isSaving)
                return;

            ReturnToAppointments();
        }
        public override void Dispose()
        {
            View.SaveRequested -= OnSaveRequested;
            View.CancelRequested -= OnCancelRequested;
        }

        private void ReturnToAppointments()
        {
            _navigationService.NavigateTo<
                ListTestAppointmentsPresenter,
                IListTestAppointmentsView>(async presenter =>
                {
                    await presenter.LoadTestAppointementsAsync(
                _localApplicationId,
                _testType);
                });
        }
    }
}
