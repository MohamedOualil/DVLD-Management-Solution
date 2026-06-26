using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public NewLocalDrivingLicenseControl()
        {
            InitializeComponent();
            StepProgressBar.Value = 20;
        }


        private void NextStepButton_Click(object sender, EventArgs e)
        {

        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
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
