

namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    public partial class NewLocalDrivingLicenseControl : UserControl, INewLocalDrivingLicenseView
    {
        public bool IsEnableNextStepButton { set => NextStepButton.Enabled = value; }
        public bool MessageLabel
        {
            set
            {
                lblMessage.Visible = value;
            }
        }
        public event EventHandler? OnNextStepRequsted;
        public event EventHandler? OnGoBackRequested;
        public NewLocalDrivingLicenseControl()
        {
            InitializeComponent();
            StepProgressBar.Value = 20;
        }


        private void NextStepButton_Click(object sender, EventArgs e)
        {
            OnNextStepRequsted?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }

        public void UpdateButtonsForState(enButtonStatus buttonState)
        {

            BackButton.Visible = true;

            switch (buttonState)
            {
                case enButtonStatus.PersonInfoStep:
                    NextStepButton.Text = "Next Step";
                    BackButton.Text = "Cancel"; 
                    break;

                case enButtonStatus.ApplicantInfoStep:
                    NextStepButton.Text = "Confirm & Save";
                    BackButton.Text = "Back";
                    break;

                case enButtonStatus.CreateApplication:
                    NextStepButton.Text = "Finish";

                    BackButton.Visible = false;
                    break;
            }
        }

        public void ShowChildView(object childView)
        {
            if (childView is Control control)
            {
                foreach (Control oldControl in ApplicationPanel.Controls)
                {
                    oldControl.Dispose();
                }

                ApplicationPanel.Controls.Clear();

                control.Dock = DockStyle.Fill;
                ApplicationPanel.Controls.Add(control);
            }
            else
            {
                throw new InvalidOperationException("The View must be a WinForms Control.");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            OnGoBackRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
