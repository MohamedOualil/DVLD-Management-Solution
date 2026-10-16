using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Persons;

namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence;

public interface IIssueDrivingLicenceView
{
    event EventHandler? IssueRequested;
    event EventHandler? CancelRequested;
    event EventHandler? ViewPersonRequested;
    string Notes { get; }
    void ResetApplication();
    void DisplayApplication(ApplicationDetailDto application);
    void DisplayEligibility(bool eligible, string title, string description);
    void SetIssueAvailability(bool enabled, string message);
    void DisplayPerson(PersonDto person);
    void DisplayMessage(string message);
}
