using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class TestResultCard : UserControl
    {
        private static readonly Image VisionTestIcon = Properties.Resources.icons8_vision_48;
        private static readonly Image WrittenTestIcon = Properties.Resources.icons8_note_48;
        private static readonly Image StreetTestIcon = Properties.Resources.icons8_car_48;
        private static readonly Image DefaultTestIcon = Properties.Resources.icons8_test_48;

        private string _status = "passed";

        public TestResultCard()
        {
            InitializeComponent();
        }

        public void LoadCardData(TestCardDto testCard)
        {
            ArgumentNullException.ThrowIfNull(testCard);
            lblResult.Text = string.IsNullOrWhiteSpace(testCard.Result) ? "—" : testCard.Result;
            lblTestDate.Text = string.IsNullOrWhiteSpace(testCard.Date) ? "—" : testCard.Date;
            lblAttemt.Text = string.IsNullOrWhiteSpace(testCard.Attempt) ? "—" : testCard.Attempt;
            lblStatus.Text = string.IsNullOrWhiteSpace(testCard.Status) ? "Unknown" : testCard.Status.Trim();
            _status = lblStatus.Text.ToLowerInvariant();

            var (background, foreground) = _status switch
            {
                "passed" => (Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52)),
                "failed" => (Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28)),
                "pending" => (Color.FromArgb(254, 243, 199), Color.FromArgb(180, 83, 9)),
                _ => (Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105))
            };
            statusPanel.FillColor = background;
            lblStatus.ForeColor = foreground;
            statusIcon.Invalidate();

            var testType = (TestTypeEnum)testCard.TestTypeId;
            switch (testType)
            {
                case TestTypeEnum.VisionTest:
                    iconPanel.FillColor = Color.FromArgb(204, 251, 241);
                    pbTestImage.Image = VisionTestIcon;
                    lblTestName.Text = "Vision test";
                    break;

                case TestTypeEnum.WrittenTest:
                    iconPanel.FillColor = Color.FromArgb(254, 243, 199);
                    pbTestImage.Image = WrittenTestIcon;
                    lblTestName.Text = "Written test";
                    break;

                case TestTypeEnum.StreetTest:
                    iconPanel.FillColor = Color.FromArgb(237, 233, 254);
                    pbTestImage.Image = StreetTestIcon;
                    lblTestName.Text = "Street test";
                    break;

                default:
                    iconPanel.FillColor = Color.FromArgb(241, 245, 249);
                    pbTestImage.Image = DefaultTestIcon;
                    lblTestName.Text = "Test";
                    break;
            }
        }

        private void statusIcon_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var background = new SolidBrush(lblStatus.ForeColor);
            e.Graphics.FillEllipse(background, 0.5F, 0.5F, 11, 11);
            using var symbol = new Pen(Color.White, 1.4F)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            if (_status == "passed")
                e.Graphics.DrawLines(symbol, new[] { new PointF(3, 6), new PointF(5, 8), new PointF(9, 4) });
            else if (_status == "failed")
            {
                e.Graphics.DrawLine(symbol, 4, 4, 8, 8);
                e.Graphics.DrawLine(symbol, 8, 4, 4, 8);
            }
            else if (_status == "pending")
                e.Graphics.DrawLines(symbol, new[] { new PointF(6, 3), new PointF(6, 6), new PointF(8, 7) });
            else
                e.Graphics.DrawLine(symbol, 4, 6, 8, 6);
        }
    }
}
