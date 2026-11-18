#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence;

public partial class IssueDrivingLicenceControl : UserControl, IIssueDrivingLicenceView
{
    public event EventHandler? IssueRequested;
    public event EventHandler? ViewPersonRequested;
    public event EventHandler? HasChangesRequested;

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Notes => notesTextBox.Text.Trim();

    public IssueDrivingLicenceControl()
    {
        InitializeComponent();

        applicantBanner.ViewPersonRequested += (_, _) => ViewPersonRequested?.Invoke(this, EventArgs.Empty);
        pageActionFooter.PrimaryActionRequested += (_, _) => IssueRequested?.Invoke(this, EventArgs.Empty);
    }

    public void ResetApplication()
    {
        applicantBanner.Reset();
        applicationMetadataCard.Reset();
        notesTextBox.Clear();
        notesTextBox.Enabled = false;

        pageHeader.BadgeText = "● Loading";
        pageHeader.BadgeTone = HeaderBadgeTone.Neutral;

        SetIssueAvailability(false, "Loading application information…");
        DisplayEligibility(false, "Loading application information…", "Please wait.");
    }

    public void DisplayApplication(LocalApplicationResponse application)
    {
        ArgumentNullException.ThrowIfNull(application);

        applicantBanner.Bind(application);
        applicationMetadataCard.Bind(application);

        if (Enum.TryParse<ApplicationStatusEnum>(application.Status, ignoreCase: true, out var status) &&
            Enum.IsDefined(typeof(ApplicationStatusEnum), status))
        {
            pageHeader.SetApplicationStatus(status);
        }
        else
        {
            pageHeader.BadgeText = $"● {application.Status}";
            pageHeader.BadgeTone = HeaderBadgeTone.Info;
        }
    }

    public void DisplayEligibility(bool eligible, string title, string description)
    {
        eligibilityBanner.SetBanner(
            title,
            description,
            eligible ? HeaderBadgeTone.Success : HeaderBadgeTone.Warning);

        notesTextBox.Enabled = eligible;
    }

    public void SetIssueAvailability(bool enabled, string message)
    {
        pageActionFooter.SetState(enabled, message, isWarningOrError: !enabled);
    }

    public void DisplayMessage(string message) => MessageBox.Show(
        this,
        message,
        "Issue Driving Licence",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

    private void notesTextBox_TextChanged(object? sender, EventArgs e)
    {
        HasChangesRequested?.Invoke(this, EventArgs.Empty);
    }
}
