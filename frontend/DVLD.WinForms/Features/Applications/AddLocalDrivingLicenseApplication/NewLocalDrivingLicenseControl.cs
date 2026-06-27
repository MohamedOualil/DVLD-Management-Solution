using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication.NewLocalDrivingLicensePresenter;

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

        public void DesignButton(enButtonStatus buttonState)
        {
            switch(buttonState) 
            {
                case enButtonStatus.Close:
                    NextStepButton.Text = "Close";
                    break;
                case enButtonStatus.Confiramtion:
                    NextStepButton.Text = "Confiramtion";
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
    }
}
