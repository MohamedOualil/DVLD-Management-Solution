

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public partial class NewLocalDrivingLicenseControl : UserControl, INewLocalDrivingLicenseView
    {
        public bool IsEnableNextStepButton
        {
            set
            {
                _canContinue = value;
                ApplyButtonState();
            }
        }
        public bool MessageLabel
        {
            set
            {
                lblMessage.Visible = value;
            }
        }
        public event EventHandler? OnNextStepRequsted;
        public event EventHandler? OnGoBackRequested;

        private enButtonStatus _step = enButtonStatus.PersonInfoStep;

        private bool _busy;
        private bool _canContinue;
        public NewLocalDrivingLicenseControl()
        {
            InitializeComponent();
            UpdateButtonsForState(enButtonStatus.PersonInfoStep);
        }


        private void NextStepButton_Click(object sender, EventArgs e)
        {
            if (!_busy && _canContinue)
                OnNextStepRequsted?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = !string.IsNullOrWhiteSpace(message);
        }

        public void UpdateButtonsForState(enButtonStatus buttonState)
        {
            _step = buttonState;

            bool created = buttonState == enButtonStatus.CreateApplication;

            BackButton.Visible = !created;
            BackButton.Text =
                buttonState == enButtonStatus.PersonInfoStep
                    ? "Cancel"
                    : "Back";

            ApplicationPanel.Visible = !created;
            successPanel.Visible = created;

            UpdateStepIndicators();
            ApplyButtonState();

        }

        public void ShowChildView(object childView)
        {

            if (childView is not Control control)
            {
                throw new ArgumentException(
                    "The child view must be a WinForms control.",
                    nameof(childView));
            }

            if (ApplicationPanel.Controls.Contains(control))
                return;

            ApplicationPanel.SuspendLayout();

            try
            {
                // Remove first: disposing a child can change the collection.
                while (ApplicationPanel.Controls.Count > 0)
                {
                    var oldControl = ApplicationPanel.Controls[0];

                    ApplicationPanel.Controls.Remove(oldControl);
                    oldControl.Dispose();
                }

                control.Dock = DockStyle.Fill;
                ApplicationPanel.Controls.Add(control);
            }
            finally
            {
                ApplicationPanel.ResumeLayout(true);
            }
        }



        private void BackButton_Click(object sender, EventArgs e)
        {
            if (!_busy)
                OnGoBackRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetBusy(bool busy)
        {
            _busy = busy;

            ApplicationPanel.Enabled = !busy;
            UseWaitCursor = busy;

            ApplyButtonState();
        }

        public void ShowCreatedApplication(int localApplicationId)
        {
            successDescription.Text =
                $"Local driving licence application #{localApplicationId} " +
                "has been created successfully.";
        }

        private void ApplyButtonState()
        {
            NextStepButton.Enabled = !_busy && _canContinue;
            BackButton.Enabled = !_busy;

            NextStepButton.Text = _busy
                ? _step == enButtonStatus.ApplicantInfoStep
                    ? "Saving…"
                    : "Loading…"
                : _step switch
                {
                    enButtonStatus.PersonInfoStep => "Next Step",
                    enButtonStatus.ApplicantInfoStep => "Confirm & Save",
                    enButtonStatus.CreateApplication => "Finish",
                    _ => "Next Step"
                };
        }


        private void UpdateStepIndicators()
        {
            var buttons = new[]
            {
                guna2Button1,
                guna2Button2,
                guna2Button3
            };

            var labels = new[]
            {
                personStepLabel,
                classStepLabel,
                createdStepLabel
            };

            int currentStep = (int)_step;

            for (int index = 0; index < buttons.Length; index++)
            {
                int stepNumber = index + 1;
                bool reached = stepNumber <= currentStep;

                buttons[index].Text = stepNumber < currentStep
                    ? "✓"
                    : stepNumber.ToString();

                buttons[index].FillColor = reached
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(226, 232, 240);

                buttons[index].ForeColor = reached
                    ? Color.White
                    : Color.FromArgb(100, 116, 139);

                labels[index].ForeColor = reached
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(100, 116, 139);
            }

            StepProgressBar.Value = (currentStep - 1) * 50;
        }
    }
}
