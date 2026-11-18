#nullable enable
using DVLD.WinForms.Features.Applications.DetainedLicenses;
using DVLD.WinForms.Features.Applications.InternationalLicenses;
using DVLD.WinForms.Features.Applications.LocalApplications;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications
{
    public partial class ApplicationsControl : UserControl, IApplicationsView
    {
        public event EventHandler? OnLoadDataRequested;
        public event EventHandler<int>? TabSelectionChanged;
        public event EventHandler? IssueLicenseRequested;
        public event EventHandler? InternationalLicenseRequested;
        public event EventHandler? RenewLicenseRequested;
        public event EventHandler? ReplaceLicenseRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ILocalApplicationsTabView LocalApplicationsView => localApplicationsTabControl;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IInternationalLicensesTabView InternationalLicensesView => internationalLicensesTabControl;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDetainedLicensesTabView DetainedLicensesView => detainedLicensesTabControl;

        public ApplicationsControl()
        {
            InitializeComponent();

            InterLicenseButton.Image = Properties.Resources.icons8_international_48;

            Load += (_, _) => OnLoadDataRequested?.Invoke(this, EventArgs.Empty);
            guna2TabControl1.SelectedIndexChanged += (_, _) => TabSelectionChanged?.Invoke(this, guna2TabControl1.SelectedIndex);
            IssueLicenseButton.Click += (_, _) => IssueLicenseRequested?.Invoke(this, EventArgs.Empty);
            InterLicenseButton.Click += (_, _) => InternationalLicenseRequested?.Invoke(this, EventArgs.Empty);
            RenewLicensseButton.Click += (_, _) => RenewLicenseRequested?.Invoke(this, EventArgs.Empty);
            ReplaceButton.Click += (_, _) => ReplaceLicenseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
