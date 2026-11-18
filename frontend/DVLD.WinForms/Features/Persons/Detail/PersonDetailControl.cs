#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.Detail
{
    public partial class PersonDetailControl : UserControl, IPersonDetailView
    {
        private static readonly Image MaleGenderBitmap = Properties.Resources.MaleIcon;
        private static readonly Image FemaleGenderBitmap = Properties.Resources.FemaleIcon;

        public PersonDetailControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullName { set => lblFullName.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DateofBirth { set => lblDateOfBirth.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NationlNo { set => lblNationalNo.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Gender
        {
            set
            {
                string display = string.IsNullOrWhiteSpace(value) ? "—" : value;
                lblGender.Text = display;

                if (display.Equals("Male", StringComparison.OrdinalIgnoreCase))
                    GenderIcon.Image = MaleGenderBitmap;
                else if (display.Equals("Female", StringComparison.OrdinalIgnoreCase))
                    GenderIcon.Image = FemaleGenderBitmap;
                else
                    GenderIcon.Image = null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Phone { set => lblPhone.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email { set => lblEmail.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Address { set => lblAddress.Text = string.IsNullOrWhiteSpace(value) ? "—" : value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PersonId
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    lblPersonId.Text = "—";
                    return;
                }

                string trimmed = value.Trim();
                lblPersonId.Text = trimmed.StartsWith('#') ? trimmed : $"#{trimmed}";
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImagePath
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && File.Exists(value))
                {
                    pbPhoto.ImageLocation = value;
                }
                else
                {
                    pbPhoto.ImageLocation = null;
                    pbPhoto.Image = Properties.Resources.DefaultAvatar;
                }
            }
        }

        public void PersonInitialized(PersonResponse personDto)
        {
            ArgumentNullException.ThrowIfNull(personDto);

            NationlNo = personDto.NationalNo;
            DateofBirth = personDto.DateOfBirth.ToString("dd MMM yyyy");
            PersonId = personDto.PersonId.ToString();
            FullName = personDto.GetFullName();
            Address = personDto.GetFullAddress();
            Email = personDto.Email ?? "—";
            Phone = personDto.Phone;
            ImagePath = personDto.ImagePath ?? string.Empty;
            Gender = ((DVLD.Contracts.Enums.Gender)personDto.Gender).ToString();
        }
    }
}
