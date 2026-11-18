#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    public partial class PersonEditorForm : Form
    {
        private string _imagePath = string.Empty;

        public PersonEditorForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.SelectedIndex = 0;

            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);

            pageHeader.BackRequested += (_, _) => CancelAndClose();
            pageActionFooter.SecondaryActionRequested += (_, _) => CancelAndClose();
            pageActionFooter.PrimaryActionRequested += (_, _) => SaveAndClose();
            btnSelectPhoto.Click += (_, _) => PickPhoto();
            btnSelectPhoto.Image = Properties.Resources.icons8_plus_teal_32;
            btnSelectPhoto.ImageSize = new Size(14, 14);

            ModalDialogShellHelper.Attach(
                this,
                borderRadius: 13f,
                onEscape: CancelAndClose,
                topAccentBar,
                pageHeader,
                formCard,
                pageActionFooter);
        }

        public void ConfigureForCreate()
        {
            pageHeader.Configure(
                "Register New Person",
                "Enter citizen identity, contact, and address details",
                "● New Person",
                HeaderBadgeTone.Info,
                showBackButton: true,
                iconText: "PR");

            txtNationalNo.Enabled = true;
        }

        public void ConfigureForEdit(PersonResponse person)
        {
            ArgumentNullException.ThrowIfNull(person);

            pageHeader.Configure(
                $"Update Person #{person.PersonId}",
                $"Editing profile for {person.NationalNo}",
                "● Edit Mode",
                HeaderBadgeTone.Warning,
                showBackButton: true,
                iconText: "PR");

            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName ?? string.Empty;
            txtThirdName.Text = person.ThirdName ?? string.Empty;
            txtLastName.Text = person.LastName;
            txtNationalNo.Text = person.NationalNo;
            txtPhone.Text = person.Phone;
            txtEmail.Text = person.Email ?? string.Empty;
            txtCity.Text = person.City;
            txtStreet.Text = person.Street;

            if (person.DateOfBirth >= dtpDateOfBirth.MinDate && person.DateOfBirth <= dtpDateOfBirth.MaxDate)
                dtpDateOfBirth.Value = person.DateOfBirth;

            cmbGender.SelectedIndex = (Gender)person.Gender == Gender.Female ? 1 : 0;
            SetPhoto(person.ImagePath);
        }

        public CreatePersonRequest BuildCreateRequest() => new()
        {
            FirstName = txtFirstName.Text.Trim(),
            SecondName = NullIfBlank(txtSecondName.Text),
            ThirdName = NullIfBlank(txtThirdName.Text),
            LastName = txtLastName.Text.Trim(),
            NationalNo = txtNationalNo.Text.Trim(),
            DateOfBirth = dtpDateOfBirth.Value.Date,
            Gender = (short)(cmbGender.SelectedIndex == 1 ? Gender.Female : Gender.Male),
            Phone = txtPhone.Text.Trim(),
            Email = NullIfBlank(txtEmail.Text),
            City = string.IsNullOrWhiteSpace(txtCity.Text) ? "Amman" : txtCity.Text.Trim(),
            Street = string.IsNullOrWhiteSpace(txtStreet.Text) ? "Main St" : txtStreet.Text.Trim(),
            State = "Central",
            ZipCode = "11118",
            CountryId = 1,
            AddressCountryId = 1,
            ImagePath = NullIfBlank(_imagePath)
        };

        public UpdatePersonRequest BuildUpdateRequest(int personId) => new()
        {
            Id = personId,
            FirstName = txtFirstName.Text.Trim(),
            SecondName = NullIfBlank(txtSecondName.Text),
            ThirdName = NullIfBlank(txtThirdName.Text),
            LastName = txtLastName.Text.Trim(),
            NationalNo = txtNationalNo.Text.Trim(),
            DateOfBirth = dtpDateOfBirth.Value.Date,
            Gender = (short)(cmbGender.SelectedIndex == 1 ? Gender.Female : Gender.Male),
            Phone = txtPhone.Text.Trim(),
            Email = NullIfBlank(txtEmail.Text),
            City = string.IsNullOrWhiteSpace(txtCity.Text) ? "Amman" : txtCity.Text.Trim(),
            Street = string.IsNullOrWhiteSpace(txtStreet.Text) ? "Main St" : txtStreet.Text.Trim(),
            State = "Central",
            ZipCode = "11118",
            CountryId = 1,
            AddressCountryId = 1,
            ImagePath = NullIfBlank(_imagePath)
        };

        private void PickPhoto()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select Citizen Photo",
                Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                SetPhoto(dialog.FileName);
        }

        private void SetPhoto(string? path)
        {
            _imagePath = path ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                pbPhoto.ImageLocation = path;
            }
            else
            {
                pbPhoto.ImageLocation = null;
                pbPhoto.Image = Properties.Resources.DefaultAvatar;
            }
        }

        private void SaveAndClose()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtNationalNo.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                pageActionFooter.SetState(true, "First Name, Last Name, National No, and Phone are required.", isWarningOrError: true);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelAndClose()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static string? NullIfBlank(string text) =>
            string.IsNullOrWhiteSpace(text) ? null : text.Trim();
    }
}
