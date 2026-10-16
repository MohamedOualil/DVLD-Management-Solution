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

namespace DVLD.WinForms.Features.Test.RecordTestResult
{
    public class RecordTestResultPresenter : BasePresenter<IRecordTestResultView>
    {
        private readonly IApplicationsService _applicationsService;
        private readonly ITestAppointmentsService _appointmentsService;
        private readonly ITestService _testService;
        private int _localId;
        private int _appointmentId;
        private TestTypeEnum _testType;
        private bool _ready;
        private bool _saving;
        private bool _saved;
        private bool _disposed;

        public RecordTestResultPresenter(IApplicationsService applicationsService,
            ITestAppointmentsService appointmentsService, ITestService testService,
            IRecordTestResultView view, AppSession session, INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _applicationsService = applicationsService;
            _appointmentsService = appointmentsService;
            _testService = testService;
            View.SaveRequested += OnSaveRequested;
            View.CancelRequested += OnCancelRequested;
        }

        public async Task LoadAsync(int localApplicationId, TestTypeEnum testType, int appointmentId)
        {
            if (_disposed || _saving) return;
            _localId = localApplicationId;
            _testType = testType;
            _appointmentId = appointmentId;

            _ready = false;
            _saved = false;

            View.SetRecordingAvailability(false, "Loading appointment information…");
            if (localApplicationId <= 0 || appointmentId <= 0 || !Enum.IsDefined(testType))
            {
                View.SetRecordingAvailability(false, "Invalid application, appointment or test type.");
                return;
            }

            try
            {
                var applicationTask = _applicationsService.GetApplicationDetails(localApplicationId);
                var appointmentsTask = _appointmentsService.GetTestAppointmentsAsync(localApplicationId, testType);
                await Task.WhenAll(applicationTask, appointmentsTask);

                if (_disposed) return;
                var application = await applicationTask;
                var appointments = await appointmentsTask;
                if (!application.IsSuccess || application.Data is null ||
                    !appointments.IsSuccess || appointments.Data is null)
                {
                    View.SetRecordingAvailability(false, "Unable to load appointment information. Go back and try again.");
                    return;
                }

                var appointment = appointments.Data.FirstOrDefault(
                                    a => a.TestAppointmentId == appointmentId);

                if (appointment is null)
                {
                    View.SetRecordingAvailability(false,
                        "This appointment does not belong to the selected application and test.");
                    return;
                }

                int attemptsCount = appointments.Data.Count;

                View.DisplayApplication(application.Data);
                View.DisplayAppointment(appointment, testType, attemptsCount);

                string? restriction = null;
                if (string.Equals(appointment.TestStatus, "Locked", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(appointment.TestResult, "Not Taken", StringComparison.OrdinalIgnoreCase))
                    restriction = "A result has already been recorded for this appointment.";

                else if (!string.Equals(application.Data.Status, "New", StringComparison.OrdinalIgnoreCase))
                    restriction = "Results can only be recorded for a new application.";

                _ready = restriction is null;
                View.SetRecordingAvailability(_ready, restriction ?? "Select Pass or Fail, then save the result.");
            }
            catch (Exception)
            {
                if (!_disposed)
                    View.SetRecordingAvailability(false, "Unable to load appointment information. Go back and try again.");
            }
        }

        private async void OnSaveRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_ready || _saving || _saved) return;
            bool? passed = View.Passed;
            if (passed is null)
            {
                View.DisplayMessage("Select Pass or Fail before saving.");
                return;
            }
            if (!_session.IsLoggedIn || _session.UserId <= 0)
            {
                View.DisplayMessage("Please log in before recording a result.");
                return;
            }

            var request = new RecordTestResultRequest
            {
                TestAppointmentId = _appointmentId,
                Result = passed.Value ? 1 : 0,
                Notes = string.IsNullOrWhiteSpace(View.Notes) ? null : View.Notes,
                CreateById = _session.UserId
            };
            _saving = true;
            View.SetSaving(true);
            try
            {
                var response = await _testService.RecordTestResultAsync(request);
                if (_disposed) return;
                if (!response.IsSuccess)
                {
                    View.DisplayMessage(response.Error?.AllMessages ?? "Could not save the test result.");
                    return;
                }
                if (response.Data is null || !response.Data.IsSuccess || response.Data.Value <= 0)
                {
                    RequireRefresh();
                    return;
                }
                _saved = true;
                _ready = false;
                View.SetRecordingAvailability(false, "Test result saved.");
                View.DisplayMessage($"Test result #{response.Data.Value} saved successfully.");
            }
            catch (Exception)
            {
                if (!_disposed) RequireRefresh();
            }
            finally
            {
                _saving = false;
                if (!_disposed) View.SetSaving(false);
            }
            if (!_disposed && _saved) ReturnToAppointments();
        }

        private void RequireRefresh()
        {
            _ready = false;
            View.SetRecordingAvailability(false,
                "The save could not be confirmed. Go back and refresh appointments to check whether the result was saved.");
        }

        private void OnCancelRequested(object? sender, EventArgs e)
        {
            if (!_disposed && !_saving) ReturnToAppointments();
        }

        private void ReturnToAppointments() =>
            _navigationService.NavigateTo<ListTestAppointmentsPresenter, IListTestAppointmentsView>(
                async presenter => await presenter.LoadTestAppointementsAsync(_localId, _testType));

        public override void Dispose()
        {
            _disposed = true;
            View.SaveRequested -= OnSaveRequested;
            View.CancelRequested -= OnCancelRequested;
        }
    }
}
