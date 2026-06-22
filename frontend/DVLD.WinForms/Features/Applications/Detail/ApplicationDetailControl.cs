using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.Detail;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public partial class ApplicationDetailControl : UserControl, IApplicationDetailView
    {
        public event EventHandler CanacleApplicationRequest;

        public event EventHandler SaveEditApplicationRequest;
        public string ApplicationId { set => lblApplicationID.Text = value; get => lblApplicationID.Text; }
        public string StatusDate { set => lblStatusDate.Text = value; }
        public string CreateBy { set => lblCreateby.Text = value; }
        public string ApplicationType { set => lblApplicationType.Text = value; }
        public string LocalApplicationId { set => lblLocalApplicationID.Text = value; get => lblLocalApplicationID.Text; }
        public string Fees { set => lblFees.Text = value; }

        public int ApplicationLicenseClass
        {
            set
            {
                CombClassLincense.SelectedIndex = value - 1;
            }

            get
            {
                return CombClassLincense.SelectedIndex;
            }
        }
        public ApplicationStatusEnum ApplicationStatus
        {
            set
            {
                statusButton.Text = value.ToString();

                statusButton.DisabledState.FillColor = value switch
                {
                    ApplicationStatusEnum.Completed => Color.Green,
                    ApplicationStatusEnum.Cancelled => Color.Red,
                    ApplicationStatusEnum.New => Color.Gray,
                    _ => Color.Gray
                };

                ShowLicenseButton.Enabled = value == ApplicationStatusEnum.Completed;
                EditButton.Enabled = value == ApplicationStatusEnum.New;
                CancelButton.Enabled = value == ApplicationStatusEnum.New;

            }
        }


        public ApplicationDetailControl()
        {
            InitializeComponent();
            LoadLicenseClass();
        }

        public void LoadLicenseClass()
        {
            List<LicenceClass> licenceClasses = new List<LicenceClass>
            {
                new LicenceClass("Small Motorcycle",LicenseClassEnum.SmallMotorcycle),
                new LicenceClass("Heavy Motorcycle License",LicenseClassEnum.HeavyMotorcycleLicense),
                new LicenceClass("Ordinary Driving License",LicenseClassEnum.OrdinaryDrivingLicense),
                new LicenceClass("Commercial",LicenseClassEnum.Commercial),
                new LicenceClass("Agricultural",LicenseClassEnum.Agricultural),
                new LicenceClass("Small and MediumBus",LicenseClassEnum.SmallandMediumBus),
                new LicenceClass("Truck and Heavy Vehicle",LicenseClassEnum.TruckandHeavyVehicle),
            };

            CombClassLincense.DataSource = licenceClasses;
            CombClassLincense.DisplayMember = "Name";
            CombClassLincense.ValueMember = "id";
            CombClassLincense.SelectedIndex = 2;
        }
        public void LoadPersonInfo(PersonDto personDto)
        {
            personDetailControl1.PersonInitialized(personDto);
        }

        public void LoadTestRoadmap(TestResultsRoadmapDto testResultsRoadmapDto)
        {
            VisionTestCard.LoadCardData(testResultsRoadmapDto.VisionTest);
            WritingTestCard.LoadCardData(testResultsRoadmapDto.WrittenTest);
            StreetTestCard.LoadCardData(testResultsRoadmapDto.StreetTest);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CanacleApplicationRequest?.Invoke(this, EventArgs.Empty);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ControlMode(StatusMode.EditMode);
        }

        public void ControlMode(StatusMode mode)
        {

            if (mode == StatusMode.EditMode)
            {
                ShowLicenseButton.Visible = false;
                CancelButton.Visible = false;
                EditButton.Visible = false;

                CombClassLincense.Enabled = true;
                SaveButton.Visible = true;
                return;
            }

            CombClassLincense.Enabled = false;
            SaveButton.Visible = false;

            ShowLicenseButton.Visible = true;
            CancelButton.Visible = true;
            EditButton.Visible = true;


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveEditApplicationRequest?.Invoke(this, EventArgs.Empty);
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }



}
