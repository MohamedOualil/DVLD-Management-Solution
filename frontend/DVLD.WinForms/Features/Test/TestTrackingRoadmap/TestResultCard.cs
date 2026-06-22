using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Test.TestTrackingRoadmap
{
    public partial class TestResultCard : UserControl
    {
        public TestResultCard()
        {
            InitializeComponent();
        }

        public void LoadCardData(TestCardDto testCard)
        {
            lblResult.Text = testCard.Result;
            lblTestDate.Text = testCard.Date;
            lblAttemt.Text = testCard.Attempt;
            TeststatusButton.Text = testCard.Status;


            TeststatusButton.FillColor = testCard.Status switch
            {
                "Passed" => ColorTranslator.FromHtml("#2ECC71"),  // Soft Green
                "Failed" => ColorTranslator.FromHtml("#E74C3C"),  // Soft Red
                "Pending" => ColorTranslator.FromHtml("#F39C12"), // Warning Orange
                "Locked" => ColorTranslator.FromHtml("#95A5A6"),  // Disabled Gray
                _ => Color.DarkGray // Default fallback color
            };


            var testType = (TestTypeEnum)testCard.TestTypeId;
            switch (testType)
            {
                case TestTypeEnum.VisionTest:
                    pbTestImage.Image = Properties.Resources.icons8_vision_48;
                    lblTestName.Text = "Vision Test";
                    break;

                case TestTypeEnum.WrittenTest:
                    pbTestImage.Image = Properties.Resources.icons8_test_48;
                    lblTestName.Text = "Written Test";
                    break;

                case TestTypeEnum.StreetTest:
                    pbTestImage.Image = Properties.Resources.icons8_car_48;
                    lblTestName.Text = "Street Test";
                    break;
            }
        }
    }
}
