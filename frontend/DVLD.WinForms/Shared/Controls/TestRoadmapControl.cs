#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class TestRoadmapControl : UserControl
    {
        private int _passedTestsCount;

        public TestRoadmapControl()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [DefaultValue("Licensing Examination Roadmap")]
        public string Title
        {
            get => lblRoadmapTitle.Text;
            set => lblRoadmapTitle.Text = string.IsNullOrWhiteSpace(value)
                ? "Licensing Examination Roadmap"
                : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PassedTestsCount => _passedTestsCount;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAllTestsPassed => _passedTestsCount == 3;

        public void Bind(TestRoadmapResponse roadmap)
        {
            ArgumentNullException.ThrowIfNull(roadmap);

            visionTestCard.LoadCardData(roadmap.VisionTest);
            writtenTestCard.LoadCardData(roadmap.WrittenTest);
            streetTestCard.LoadCardData(roadmap.StreetTest);

            _passedTestsCount = new[] { roadmap.VisionTest, roadmap.WrittenTest, roadmap.StreetTest }
                .Count(t => string.Equals(t?.Status, "Passed", StringComparison.OrdinalIgnoreCase));

            UpdateEligibilityBadge(_passedTestsCount);
        }

        public void Reset()
        {
            visionTestCard.LoadCardData(CreateEmptyCard(TestTypeEnum.VisionTest));
            writtenTestCard.LoadCardData(CreateEmptyCard(TestTypeEnum.WrittenTest));
            streetTestCard.LoadCardData(CreateEmptyCard(TestTypeEnum.StreetTest));

            _passedTestsCount = 0;
            UpdateEligibilityBadge(0);
        }

        private void UpdateEligibilityBadge(int passedCount)
        {
            string text;
            Color fill;
            Color border;
            Color fore;

            if (passedCount >= 3)
            {
                text = "● 3 of 3 Tests Passed — Ready";
                fill = Color.FromArgb(240, 253, 244);
                border = Color.FromArgb(187, 247, 208);
                fore = Color.FromArgb(21, 128, 61);
            }
            else if (passedCount > 0)
            {
                text = $"● {passedCount} of 3 Tests Passed";
                fill = Color.FromArgb(240, 253, 250);
                border = Color.FromArgb(153, 246, 228);
                fore = Color.FromArgb(15, 118, 110);
            }
            else
            {
                text = "○ 0 of 3 Tests Passed";
                fill = Color.FromArgb(248, 250, 252);
                border = Color.FromArgb(226, 232, 240);
                fore = Color.FromArgb(71, 85, 105);
            }

            eligibilityBadge.Text = text;
            eligibilityBadge.FillColor = fill;
            eligibilityBadge.BorderColor = border;
            eligibilityBadge.ForeColor = fore;
            eligibilityBadge.HoverState.FillColor = fill;
            eligibilityBadge.HoverState.BorderColor = border;
            eligibilityBadge.HoverState.ForeColor = fore;
            eligibilityBadge.PressedColor = fill;
        }

        private static TestCardDto CreateEmptyCard(TestTypeEnum type) => new()
        {
            TestTypeId = (int)type,
            Status = "Locked",
            Date = "—",
            Attempt = "Not Scheduled",
            Result = "—"
        };
    }
}
