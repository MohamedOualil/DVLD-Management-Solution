using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared;

namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence;

public class IssueDrivingLicencePresenter : BasePresenter<IIssueDrivingLicenceView>
{
    private const string IssuanceUnavailable = "Licence issuance is not connected yet.";
    private readonly IApplicationsService _applicationsService;
    private readonly IPesronService _personService;
    private int _personId;
    private int _loadVersion;
    private bool _loadingPerson;
    private bool _disposed;

    public IssueDrivingLicencePresenter(IIssueDrivingLicenceView view,
        IApplicationsService applicationsService, IPesronService personService,
        AppSession session, INavigationService navigationService)
        : base(view, session, navigationService)
    {
        _applicationsService = applicationsService;
        _personService = personService;
        View.IssueRequested += OnIssueRequested;
        View.CancelRequested += OnCancelRequested;
        View.ViewPersonRequested += OnViewPersonRequested;
        View.ResetApplication();
    }

    public async Task LoadAsync(int localApplicationId)
    {
        if (_disposed) return;
        int version = ++_loadVersion;
        _personId = 0;
        View.ResetApplication();
        if (localApplicationId <= 0)
        {
            ShowLoadError("Select a valid local driving licence application.");
            return;
        }

        try
        {
            var applicationTask = _applicationsService.GetApplicationDetails(localApplicationId);
            var testsTask = _applicationsService.GetTestResultsRoadmap(localApplicationId);
            await Task.WhenAll(applicationTask, testsTask);
            if (_disposed || version != _loadVersion) return;
            var application = await applicationTask;
            var tests = await testsTask;
            if (!application.IsSuccess || application.Data is null ||
                !tests.IsSuccess || tests.Data is null)
            {
                ShowLoadError("Unable to load application information. Go back and try again.");
                return;
            }

            var data = application.Data;
            if (data.LocalId != localApplicationId || tests.Data.LocalApplicationId != localApplicationId)
            {
                ShowLoadError("The returned details do not match the selected application.");
                return;
            }
            _personId = data.PersonId;
            View.DisplayApplication(data);

            int passed = new[] { tests.Data.VisionTest, tests.Data.WrittenTest, tests.Data.StreetTest }
                .Count(test => string.Equals(test?.Status, "Passed", StringComparison.OrdinalIgnoreCase));

            bool eligible = passed == 3 && string.Equals(data.Status, "New", StringComparison.OrdinalIgnoreCase);

            View.DisplayEligibility(eligible,
                eligible ? "All required tests passed" : "Application is not ready for issuance",
                $"{passed} of 3 tests completed · Status: {data.Status}");
            // The API action currently returns a placeholder ID. Do not report a successful issue.
            View.SetIssueAvailability(false, eligible ? IssuanceUnavailable : "A new application and all 3 passed tests are required.");
        }
        catch (Exception)
        {
            if (!_disposed && version == _loadVersion)
                ShowLoadError("Unable to load application information. Go back and try again.");
        }
    }

    private void ShowLoadError(string message)
    {
        View.DisplayEligibility(false, "Application unavailable", message);
        View.SetIssueAvailability(false, "Go back and try again.");
    }

    private void OnIssueRequested(object? sender, EventArgs e)
    {
        if (!_disposed) View.DisplayMessage(IssuanceUnavailable);
    }

    private void OnCancelRequested(object? sender, EventArgs e)
    {
        if (!_disposed)
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
    }

    private async void OnViewPersonRequested(object? sender, EventArgs e)
    {
        if (_disposed || _loadingPerson || _personId <= 0) return;
        _loadingPerson = true;
        int version = _loadVersion;
        try
        {
            var response = await _personService.GetPerson(_personId);
            if (_disposed || version != _loadVersion) return;
            if (response.IsSuccess && response.Data is not null)
                View.DisplayPerson(response.Data);
            else
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load person information.");
        }
        catch (Exception)
        {
            if (!_disposed && version == _loadVersion)
                View.DisplayMessage("Unable to load person information. Please try again.");
        }
        finally { _loadingPerson = false; }
    }

    public override void Dispose()
    {
        _disposed = true;
        ++_loadVersion;
        View.IssueRequested -= OnIssueRequested;
        View.CancelRequested -= OnCancelRequested;
        View.ViewPersonRequested -= OnViewPersonRequested;
    }
}
