using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.Detail;

namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence;

public partial class IssueDrivingLicenceControl : UserControl, IIssueDrivingLicenceView
{
    public event EventHandler? IssueRequested;
    public event EventHandler? CancelRequested;
    public event EventHandler? ViewPersonRequested;
    public string Notes => notesTextBox.Text.Trim();

    public IssueDrivingLicenceControl()
    {
        InitializeComponent();
        issueButton.Click += (_, _) => IssueRequested?.Invoke(this, EventArgs.Empty);
        cancelButton.Click += (_, _) => CancelRequested?.Invoke(this, EventArgs.Empty);
        viewPersonLink.LinkClicked += (_, _) => ViewPersonRequested?.Invoke(this, EventArgs.Empty);
    }

    private void closeButton_Click(object? sender, EventArgs e)
    {
        CancelRequested?.Invoke(this, EventArgs.Empty);
    }

    public void ResetApplication()
    {
        foreach (var label in new[] { localIdValue, classValue, applicationIdValue, applicantValue,
            applicationTypeValue, feeValue, statusValue, dateValue, statusDateValue, creatorValue })
            label.Text = "—";
        notesTextBox.Clear();
        notesTextBox.Enabled = false;
        viewPersonLink.Enabled = false;
        SetIssueAvailability(false, "Loading application information…");
        DisplayEligibility(false, "Loading application information…", "Please wait.");
    }

    public void DisplayApplication(ApplicationDetailDto application)
    {
        localIdValue.Text = application.LocalId.ToString();
        classValue.Text = application.LicenseClassName;
        applicationIdValue.Text = application.ApplicationId.ToString();
        applicantValue.Text = application.FullName;
        applicationTypeValue.Text = application.ApplicationType;
        feeValue.Text = application.PaidFees.ToString("0.00");
        statusValue.Text = application.Status;
        dateValue.Text = application.ApplicationDate.ToString("dd MMM yyyy");
        statusDateValue.Text = application.LastStatusDate.ToString("dd MMM yyyy");
        creatorValue.Text = application.CreatedBy;
        viewPersonLink.Enabled = application.PersonId > 0;
    }

    public void DisplayEligibility(bool eligible, string title, string description)
    {
        eligibilityTitle.Text = title;
        eligibilitySubtitle.Text = description;
        passedIcon.Text = eligible ? "✓" : "i";
        eligibilityPanel.FillColor = eligible ? Color.FromArgb(234, 249, 241) : Color.FromArgb(234, 243, 255);
        eligibilityPanel.BorderColor = eligible ? Color.FromArgb(176, 226, 198) : Color.FromArgb(208, 220, 238);
        eligibilityTitle.ForeColor = passedIcon.ForeColor = eligible
            ? Color.FromArgb(19, 103, 65) : Color.FromArgb(26, 59, 116);
        notesTextBox.Enabled = eligible;
    }

    public void SetIssueAvailability(bool enabled, string message)
    {
        issueButton.Enabled = enabled;
        footerHint.Text = message;
    }

    public void DisplayPerson(PersonDto person)
    {
        using var detail = new PersonDetailControl();
        detail.PersonInitialized(person);
        using var dialog = new Form
        {
            Text = "Person information", StartPosition = FormStartPosition.CenterParent,
            ClientSize = detail.Size, MinimizeBox = false, MaximizeBox = false,
            ShowInTaskbar = false
        };
        detail.Dock = DockStyle.Fill;
        dialog.Controls.Add(detail);
        dialog.ShowDialog(this);
    }

    public void DisplayMessage(string message) => MessageBox.Show(this, message,
        "Issue Driving Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
