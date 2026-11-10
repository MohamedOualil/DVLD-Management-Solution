using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Auth
{
    public partial class LoginForm : Form, ILoginView
    {
        public event EventHandler<EventArgs>? OnLogin;
        public event EventHandler? OnViewLoaded;
        private readonly LoginPresenter _presenter;

        public LoginForm(LoginPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this);

            label1.Cursor = Cursors.Hand;
            label1.Click += (s, e) => RemebermeSwitch.Checked = !RemebermeSwitch.Checked;
            this.AcceptButton = btnLogin;
        }

        public string Username
        {
            get => txtUsername.Text.Trim();
            set => txtUsername.Text = value ?? string.Empty;
        }

        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value ?? string.Empty;
        }

        public bool RememberMe
        {
            get => RemebermeSwitch.Checked;
            set => RemebermeSwitch.Checked = value;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnViewLoaded?.Invoke(this, EventArgs.Empty);

            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                btnLogin.Select();
            }
            else if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtPassword.Select();
            }
            else
            {
                txtUsername.Select();
            }
        }

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
