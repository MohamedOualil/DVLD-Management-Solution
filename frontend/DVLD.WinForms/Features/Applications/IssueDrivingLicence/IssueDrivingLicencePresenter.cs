using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared;

namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence;

public class IssueDrivingLicencePresenter : BasePresenter<IIssueDrivingLicenceView>
{
    private readonly ILicensesService _licensesService;
    private int _localApplicationId;
    private bool _eligible;
    private bool _issuing;
    private readonly IApplicationsService _applicationsService;
    private readonly IPesronService _personService;
    private int _personId;
    private bool _loadingPerson;
    private bool _disposed;

    public IssueDrivingLicencePresenter(IIssueDrivingLicenceView view,
        IApplicationsService applicationsService, IPesronService personService, ILicensesService licensesService,
        AppSession session, INavigationService navigationService)
        : base(view, session, navigationService)
    {
        _applicationsService = applicationsService;
        _licensesService = licensesService;
        _personService = personService;
        View.IssueRequested += OnIssueRequested;
        View.CancelRequested += OnCancelRequested;
        View.ViewPersonRequested += OnViewPersonRequested;
        View.ResetApplication();
    }

    public async Task LoadAsync(int localApplicationId)
    {
        if (_disposed || _issuing) return;
        _eligible = false;
        _localApplicationId = 0;
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

            if (_disposed) return;

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
            _eligible = eligible;
            _localApplicationId = localApplicationId;
            View.SetIssueAvailability(eligible, eligible ? "Ready to issue the driving licence." : "A new application and all 3 passed tests are required.");
        }
        catch (Exception)
        {
            if (!_disposed )
                ShowLoadError("Unable to load application information. Go back and try again.");
        }
    }

    private void ShowLoadError(string message)
    {
        View.DisplayEligibility(false, "Application unavailable", message);
        View.SetIssueAvailability(false, "Go back and try again.");
    }

    private async void OnIssueRequested(object? sender, EventArgs e)
    {
        if (_disposed || _issuing || !_eligible || _localApplicationId <= 0) return;
        _issuing = true;
        View.SetIssueAvailability(false, "Issuing driving licence…");
        try
        {
            var response = await _licensesService.IssueDrivingLicenceAsync(new IssueNewLicenseRequest
            {
                LocalApplicationId = _localApplicationId,
                CreatedByUserId = _session.UserId,
                Notes = View.Notes
            });
            if (_disposed) return;

            if (!response.IsSuccess || response.Data <= 0)
            {
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to issue the driving licence.");
                return;
            }

            _eligible = false;
            View.DisplayMessage($"Driving licence #{response.Data} issued successfully.");
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }
        catch (Exception)
        {
            if (!_disposed)
            {
                _eligible = false;
                View.DisplayMessage("Unable to confirm issuance. Return to the applications list and check its status before trying again.");
            }
        }
        finally
        {
            _issuing = false;
            if (!_disposed)
                View.SetIssueAvailability(_eligible, _eligible ? "Ready to issue the driving licence." : "Return to the applications list to check the updated status.");
        }



    }

    private void OnCancelRequested(object? sender, EventArgs e)
    {
        if (!_disposed && !_issuing)
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
    }

    private async void OnViewPersonRequested(object? sender, EventArgs e)
    {
        if (_disposed || _loadingPerson || _personId <= 0) return;
        _loadingPerson = true;

        try
        {
            var response = await _personService.GetPerson(_personId);
            if (_disposed ) return;

            if (response.IsSuccess && response.Data is not null)
                _navigationService.ShowDialog<PersonCardForm>(form => form.DisplayPerson(response.Data));
            else
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load person information.");
        }
        catch (Exception)
        {
            if (!_disposed)
                View.DisplayMessage("Unable to load person information. Please try again.");
        }
        finally { _loadingPerson = false; }
    }

    public override void Dispose()
    {
        _disposed = true;
        View.IssueRequested -= OnIssueRequested;
        View.CancelRequested -= OnCancelRequested;
        View.ViewPersonRequested -= OnViewPersonRequested;
    }
}
