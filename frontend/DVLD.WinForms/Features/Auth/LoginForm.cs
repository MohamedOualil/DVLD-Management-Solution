using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Auth
{
    public partial class LoginForm : Form , ILoginView
    {
        public event EventHandler<EventArgs> OnLogin;
        private readonly LoginPresenter _presenter;
        public LoginForm(LoginPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this);
        }

        public string Username => txtUsername.Text.Trim();

        public string Password => txtPassword.Text;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OnLogin?.Invoke(this, EventArgs.Empty);
        }

        public void ShowError(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

        public void ShowLoading(bool isLoading)
        {
            btnLogin.Enabled = !isLoading;

            if (isLoading)
            {
                lblErrorMessage.Visible = false;
            }

            loader.Visible = isLoading;
        }


    }
}
