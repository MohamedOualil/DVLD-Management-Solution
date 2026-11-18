#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Persons;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public partial class ApplicationDetailControl : UserControl, IApplicationDetailView
    {
        private ApplicationStatusEnum _applicationStatus = ApplicationStatusEnum.New;
        private StatusMode _mode = StatusMode.ViewMode;

        public event EventHandler? CanacleApplicationRequest;
        public event EventHandler? ShowLicenses;
        public event EventHandler? SaveEditApplicationRequest;

        public ApplicationDetailControl()
        {
            InitializeComponent();

            EditButton.Image = Properties.Resources.icons8_edit_white_32;

            WireFooterEvents();
            ApplyModeAndStatus();
        }

        private void WireFooterEvents()
        {
            pageActionFooter.PrimaryActionRequested += (_, _) =>
            {
                if (_mode == StatusMode.EditMode)
                    SaveEditApplicationRequest?.Invoke(this, EventArgs.Empty);
                else
                    ShowLicenses?.Invoke(this, EventArgs.Empty);
            };

            pageActionFooter.SecondaryActionRequested += (_, _) => ControlMode(StatusMode.ViewMode);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationId
        {
            get => applicationMetadataCard.ApplicationId.TrimStart('#');
            set => applicationMetadataCard.ApplicationId = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LocalApplicationId
        {
            get => applicationMetadataCard.LocalApplicationId.TrimStart('#');
            set => applicationMetadataCard.LocalApplicationId = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StatusDate { set => applicationMetadataCard.StatusDateText = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CreateBy { set => applicationMetadataCard.CreatedBy = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationType { set => applicationMetadataCard.ApplicationType = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Fees { set => applicationMetadataCard.PaidFeesText = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ApplicationLicenseClass
        {
            get => applicationMetadataCard.SelectedLicenseClassId;
            set => applicationMetadataCard.SelectedLicenseClassId = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ApplicationStatusEnum ApplicationStatus
        {
            set
            {
                _applicationStatus = value;
                applicationMetadataCard.ApplicationStatus = value;

                var tone = value switch
                {
                    ApplicationStatusEnum.Completed => HeaderBadgeTone.Success,
                    ApplicationStatusEnum.Cancelled => HeaderBadgeTone.Danger,
                    _ => HeaderBadgeTone.Info
                };
                var (fill, border, fore) = UITheme.GetBadgeColors(tone);

                statusButton.Text = $"● {value}";
                statusButton.FillColor = fill;
                statusButton.BorderColor = border;
                statusButton.ForeColor = fore;
                statusButton.DisabledState.FillColor = fill;
                statusButton.DisabledState.BorderColor = border;
                statusButton.DisabledState.ForeColor = fore;

                ApplyModeAndStatus();
            }
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(
                this,
                message,
                "Application details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void SetBusy(bool busy)
        {
            pageLayout.Enabled = !busy;
            UseWaitCursor = busy;

            if (_mode == StatusMode.EditMode)
                pageActionFooter.SetBusy(busy, "Saving…");
        }

        public void LoadPersonInfo(PersonResponse personDto)
        {
            personDetailControl1.PersonInitialized(personDto);
        }

        public void LoadTestRoadmap(TestRoadmapResponse testResultsRoadmapDto)
        {
            testRoadmapControl.Bind(testResultsRoadmapDto);
        }

        public void ControlMode(StatusMode mode)
        {
            _mode = mode;
            ApplyModeAndStatus();
        }

        private void ApplyModeAndStatus()
        {
            bool isEdit = _mode == StatusMode.EditMode;
            bool isNew = _applicationStatus == ApplicationStatusEnum.New;
            bool isCompleted = _applicationStatus == ApplicationStatusEnum.Completed;

            applicationMetadataCard.IsLicenseClassEditable = isEdit;
            EditButton.Visible = !isEdit;
            CancelButton.Visible = !isEdit;
            EditButton.Enabled = isNew;
            CancelButton.Enabled = isNew;

            if (isEdit)
            {
                pageActionFooter.ShowSecondaryButton = true;
                pageActionFooter.SecondaryButtonText = "Cancel Edit";
                pageActionFooter.PrimaryButtonText = "Save Changes";
                pageActionFooter.SetState(true, "Choose a new licence class and click Save Changes to apply.");
            }
            else
            {
                pageActionFooter.ShowSecondaryButton = false;
                pageActionFooter.PrimaryButtonText = "Show Licence";
                pageActionFooter.SetState(
                    isCompleted,
                    isCompleted
                        ? "Application completed — open the issued driving licence card."
                        : "Licence details are available after the application is completed.");
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            CanacleApplicationRequest?.Invoke(this, EventArgs.Empty);
        }

        private void EditButton_Click(object? sender, EventArgs e)
        {
            ControlMode(StatusMode.EditMode);
        }
    }
}
