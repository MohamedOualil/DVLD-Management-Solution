namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    public partial class LicenseCardForm : Form
    {
        public LicenseCardForm()
        {
            InitializeComponent();
        }

        public void DisplayLicense(LicenseDto licenseDto)
        {
            ArgumentNullException.ThrowIfNull(licenseDto);
            licenseCardControl1.LicenseInitialized(licenseDto);
        }

    }
}
