using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Test.ScheduleTest;
using DVLD.WinForms.Features.Test.RecordTestResult;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using Microsoft.Extensions.Logging;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public class ListTestAppointmentsPresenter : BasePresenter<IListTestAppointmentsView>
    {
        private int _localId;
        private TestTypeEnum _testTypeEnum;
        private bool _canSchedule;
        private bool _disposed;
        private readonly ITestAppointmentsService _testAppointmentsService;
        private readonly IApplicationsService _applicationsService;
        private readonly ILogger<ListTestAppointmentsPresenter> _logger;

        public ListTestAppointmentsPresenter(
            ITestAppointmentsService testAppointmentsService,
            IApplicationsService applicationsService,
            ILogger<ListTestAppointmentsPresenter> logger,
            IListTestAppointmentsView view,
            AppSession session,
            INavigationService navigationService) : base(view, session, navigationService)
        {
            _testAppointmentsService = testAppointmentsService;
            _applicationsService = applicationsService;
            _logger = logger;
            View.CreateAppointmentRequested += View_CreateAppointmentRequested;
            View.BackRequested += View_BackRequested;
            View.RecordResultRequested += OnRecordResultRequested;
        }

        private void View_BackRequested(object? sender, EventArgs e) =>
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();

        private void OnRecordResultRequested(object? sender, int appointmentId)
        {
            if (_disposed) return;
            _navigationService.NavigateTo<RecordTestResultPresenter, IRecordTestResultView>(
                async presenter => await presenter.LoadAsync(_localId, _testTypeEnum, appointmentId));
        }

        private void View_CreateAppointmentRequested(object? sender, EventArgs e)
        {
            if (!_canSchedule) return;
            _navigationService.NavigateTo<ScheduleTestPresenter, IScheduleTestView>(async presenter =>
            {
                await presenter.LoadTestInfoAsync(_localId, _testTypeEnum);
            });
        }

        public async Task LoadTestAppointementsAsync(int localApplicationId, TestTypeEnum testTypeEnum)
        {
            _localId = localApplicationId;
            _testTypeEnum = testTypeEnum;
            _canSchedule = false;
            View.SetSchedulingAvailability(false, "Loading appointment information…");
            try
            {
                var appointmentsTask = _testAppointmentsService.GetTestAppointmentsAsync(localApplicationId, testTypeEnum);
                var applicationTask = _applicationsService.GetApplicationDetails(localApplicationId);
                var roadmapTask = _applicationsService.GetTestResultsRoadmap(localApplicationId);

                await Task.WhenAll(appointmentsTask, applicationTask, roadmapTask);

                if (_disposed) return;

                var appointments = await appointmentsTask;
                var application = await applicationTask;
                var roadmap = await roadmapTask;

                if (application.IsSuccess && application.Data is not null)
                    View.DisplayApplication(application.Data, testTypeEnum);

                if (roadmap.IsSuccess && roadmap.Data is not null)
                    View.DisplayProgress(roadmap.Data);

                if (appointments.IsSuccess && appointments.Data is not null)
                    View.DisplayTestAppointments(appointments.Data);

                if (!appointments.IsSuccess || appointments.Data is null ||
                    !application.IsSuccess || application.Data is null ||
                    !roadmap.IsSuccess || roadmap.Data is null)
                {
                    _logger.LogWarning("Incomplete appointment page response. LocalApplicationId={LocalApplicationId}", localApplicationId);
                    View.SetSchedulingAvailability(false, "Unable to load all appointment information. Go back and try again.");
                    return;
                }

                string? reason = GetSchedulingRestriction(application.Data, roadmap.Data, appointments.Data, testTypeEnum);
                _canSchedule = reason is null;
                View.SetSchedulingAvailability(_canSchedule, reason ??
                    (appointments.Data.Count == 0 ? "No appointments scheduled yet. Create an appointment to get started."
                        : "You can schedule the next attempt for this test."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load appointments. LocalApplicationId={LocalApplicationId}", localApplicationId);
                if (!_disposed)
                    View.SetSchedulingAvailability(false, "Unable to load appointments. Go back and try again.");
            }
        }

        private static string? GetSchedulingRestriction(ApplicationDetailDto application,
            TestResultsRoadmapDto roadmap, List<TestAppointmentsRespondDto> appointments, TestTypeEnum type)
        {
            if (!Enum.IsDefined(type)) return "This test type is unavailable.";

            if (!string.Equals(application.Status, "New", StringComparison.OrdinalIgnoreCase))
                return "Appointments can only be scheduled for a new application.";

            if (appointments.Any(a => !string.Equals(a.TestStatus, "Locked", StringComparison.OrdinalIgnoreCase)))
                return "An appointment is already scheduled for this test.";

            if (appointments.Any(a => a.TestResult is "Success" or "Passed"))
                return "This test has already been passed.";

            if (appointments.Count(a => a.TestStatus == "Locked") >= 3)
                return "The maximum number of attempts for this test has been reached.";

            if (type == TestTypeEnum.WrittenTest && roadmap.VisionTest.Status != "Passed")
                return "Pass the vision test before scheduling the written test.";

            if (type == TestTypeEnum.StreetTest && roadmap.WrittenTest.Status != "Passed")
                return "Pass the written test before scheduling the street test.";

            return null;
        }

        public override void Dispose()
        {
            _disposed = true;
            View.CreateAppointmentRequested -= View_CreateAppointmentRequested;
            View.BackRequested -= View_BackRequested;
            View.RecordResultRequested -= OnRecordResultRequested;
        }
    }
}
