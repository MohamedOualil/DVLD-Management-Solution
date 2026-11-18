#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class ApplicationMetadataCardControl : UserControl
    {
        private ApplicationStatusEnum _applicationStatus = ApplicationStatusEnum.New;
        private bool _suppressClassChange;

        public event EventHandler<int>? LicenseClassChanged;

        public ApplicationMetadataCardControl()
        {
            InitializeComponent();
            LoadLicenseClasses();

            cmbLicenseClass.SelectionChangeCommitted += (_, _) =>
            {
                if (_suppressClassChange)
                    return;

                int classId = SelectedLicenseClassId;
                if (classId > 0)
                    LicenseClassChanged?.Invoke(this, classId);
            };
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LocalApplicationId
        {
            get => lblLocalApplicationID.Text;
            set => lblLocalApplicationID.Text = FormatId(value);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationId
        {
            get => lblApplicationID.Text;
            set => lblApplicationID.Text = FormatId(value);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationType
        {
            get => lblApplicationType.Text;
            set => lblApplicationType.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PaidFeesText
        {
            get => lblFees.Text;
            set => lblFees.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationDateText
        {
            get => lblApplicationDate.Text;
            set => lblApplicationDate.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StatusDateText
        {
            get => lblStatusDate.Text;
            set => lblStatusDate.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CreatedBy
        {
            get => lblCreatedBy.Text;
            set => lblCreatedBy.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedLicenseClassId
        {
            get => cmbLicenseClass.SelectedValue is LicenseClassEnum value ? (int)value : 0;
            set
            {
                _suppressClassChange = true;
                try
                {
                    if (Enum.IsDefined(typeof(LicenseClassEnum), value))
                        cmbLicenseClass.SelectedValue = (LicenseClassEnum)value;
                    else
                        cmbLicenseClass.SelectedIndex = -1;
                }
                finally
                {
                    _suppressClassChange = false;
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IsLicenseClassEditable
        {
            get => cmbLicenseClass.Enabled;
            set => cmbLicenseClass.Enabled = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ApplicationStatusEnum ApplicationStatus
        {
            get => _applicationStatus;
            set
            {
                _applicationStatus = value;
                ApplyStatusBadge(value);
            }
        }

        public void Bind(LocalApplicationResponse application)
        {
            ArgumentNullException.ThrowIfNull(application);

            var culture = CultureInfo.CurrentCulture;

            LocalApplicationId = application.LocalId.ToString();
            ApplicationId = application.ApplicationId.ToString();
            ApplicationType = application.ApplicationType;
            PaidFeesText = application.PaidFees.ToString("C2", culture);
            ApplicationDateText = application.ApplicationDate == default
                ? "—"
                : application.ApplicationDate.ToString("dd MMM yyyy", culture);
            StatusDateText = application.LastStatusDate?.ToString("dd MMM yyyy", culture) ?? "—";
            CreatedBy = application.CreatedBy;
            SelectedLicenseClassId = application.LicenseClassId;

            if (Enum.TryParse<ApplicationStatusEnum>(application.Status, ignoreCase: true, out var status) &&
                Enum.IsDefined(typeof(ApplicationStatusEnum), status))
            {
                ApplicationStatus = status;
            }
            else
            {
                ApplicationStatus = ApplicationStatusEnum.New;
                if (!string.IsNullOrWhiteSpace(application.Status))
                    statusPill.Text = $"● {application.Status.Trim()}";
            }
        }

        public void SelectLicenseClassByName(string? className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return;

            string trimmed = className.Trim();
            if (cmbLicenseClass.DataSource is not List<LicenceClass> items)
                return;

            var match = items.Find(c =>
                c.Name.Equals(trimmed, StringComparison.OrdinalIgnoreCase) ||
                c.Name.Contains(trimmed, StringComparison.OrdinalIgnoreCase) ||
                trimmed.Contains(c.Name, StringComparison.OrdinalIgnoreCase));

            if (match is not null)
                SelectedLicenseClassId = (int)match.id;
        }

        public void Reset()
        {
            LocalApplicationId = string.Empty;
            ApplicationId = string.Empty;
            ApplicationType = "—";
            PaidFeesText = "—";
            ApplicationDateText = "—";
            StatusDateText = "—";
            CreatedBy = "—";
            SelectedLicenseClassId = (int)LicenseClassEnum.OrdinaryDrivingLicense;
            ApplicationStatus = ApplicationStatusEnum.New;
        }

        private void LoadLicenseClasses()
        {
            _suppressClassChange = true;
            try
            {
                var classes = new List<LicenceClass>
                {
                    new("Class 1 - Small Motorcycle", LicenseClassEnum.SmallMotorcycle),
                    new("Class 2 - Heavy Motorcycle License", LicenseClassEnum.HeavyMotorcycleLicense),
                    new("Class 3 - Ordinary Driving License", LicenseClassEnum.OrdinaryDrivingLicense),
                    new("Class 4 - Commercial", LicenseClassEnum.Commercial),
                    new("Class 5 - Agricultural", LicenseClassEnum.Agricultural),
                    new("Class 6 - Small & Medium Bus", LicenseClassEnum.SmallandMediumBus),
                    new("Class 7 - Truck & Heavy Vehicle", LicenseClassEnum.TruckandHeavyVehicle),
                };

                cmbLicenseClass.DataSource = classes;
                cmbLicenseClass.DisplayMember = nameof(LicenceClass.Name);
                cmbLicenseClass.ValueMember = nameof(LicenceClass.id);
                cmbLicenseClass.SelectedValue = LicenseClassEnum.OrdinaryDrivingLicense;
            }
            finally
            {
                _suppressClassChange = false;
            }
        }

        private void ApplyStatusBadge(ApplicationStatusEnum status)
        {
            var (label, fill, border, fore) = status switch
            {
                ApplicationStatusEnum.Completed => (
                    "● Completed",
                    Color.FromArgb(240, 253, 244),
                    Color.FromArgb(187, 247, 208),
                    Color.FromArgb(21, 128, 61)),
                ApplicationStatusEnum.Cancelled => (
                    "● Cancelled",
                    Color.FromArgb(254, 242, 242),
                    Color.FromArgb(254, 202, 202),
                    Color.FromArgb(185, 28, 28)),
                _ => (
                    "● New",
                    Color.FromArgb(240, 253, 250),
                    Color.FromArgb(153, 246, 228),
                    Color.FromArgb(15, 118, 110))
            };

            statusPill.Text = label;
            statusPill.FillColor = fill;
            statusPill.BorderColor = border;
            statusPill.ForeColor = fore;
            statusPill.HoverState.FillColor = fill;
            statusPill.HoverState.BorderColor = border;
            statusPill.HoverState.ForeColor = fore;
            statusPill.PressedColor = fill;
        }

        private static string FormatId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "—";

            string trimmed = value.Trim();
            return trimmed.StartsWith('#') ? trimmed : $"#{trimmed}";
        }
    }
}
