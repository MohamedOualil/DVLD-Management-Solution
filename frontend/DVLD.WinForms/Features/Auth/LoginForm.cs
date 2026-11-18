#nullable enable
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
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
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            _presenter = presenter;
            _presenter.SetView(this);

            label1.Cursor = Cursors.Hand;
            label1.Click += (s, e) => RemebermeSwitch.Checked = !RemebermeSwitch.Checked;
            this.AcceptButton = btnLogin;

            txtUsername.IconLeft = Properties.Resources.icons8_users_32;
            txtPassword.IconLeft = Properties.Resources.icons8_lock_32;

            ModalDialogShellHelper.Attach(this, borderRadius: 16f, onEscape: Close, pictureBox1);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Username
        {
            get => txtUsername.Text.Trim();
            set => txtUsername.Text = value ?? string.Empty;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value ?? string.Empty;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
