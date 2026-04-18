using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.Detail
{
    public partial class PersonDetailControl : UserControl , IPersonDetailView
    {
        public event EventHandler<int> OnPersonIdReceived;
        public PersonDetailControl()
        {
            InitializeComponent();
            
        }

        public string FullName { set => lblFullName.Text = value; }
        public string DateofBirth { set => lblDateOfBirth.Text = value; }
        public string NationlNo { set => lblNationalNo.Text = value; }
        public string Gender 
        {
            set
            {
                lblGender.Text = value;

                if (value.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    GenderIcon.Image = Properties.Resources.MaleIcon;
                }
                else if (value.Equals("Female", StringComparison.OrdinalIgnoreCase))
                {
                    GenderIcon.Image = Properties.Resources.FemaleIcon;
                }
                else
                {
                    GenderIcon.Image = null;
                }
            }
        }
        public string Phone { set => lblPhone.Text = value; }
        public string Email { set => lblEmail.Text = value; }
        public string Address { set => lblAddress.Text = value; }
        public string PersonId { set => lblPersonId.Text = value; }
        public string ImagePath 
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    pbPhoto.ImageLocation = value;
                }
                else
                {

                    pbPhoto.Image = Properties.Resources.DefaultAvatar;
                }
            }

        }

        public void LoadPersonData(int personId)
        {
            OnPersonIdReceived?.Invoke(this,personId);
        }
    }
}
