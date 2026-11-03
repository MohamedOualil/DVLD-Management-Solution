using DVLD.Contracts.Licenses;
namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    public partial class LicenseCardForm : Form
    {
        public LicenseCardForm()
        {
            InitializeComponent();
        }

        public void DisplayLicense(GetLicenseResponse licenseDto)
        {
            ArgumentNullException.ThrowIfNull(licenseDto);
            licenseCardControl1.LicenseInitialized(licenseDto);
        }

    }
}
