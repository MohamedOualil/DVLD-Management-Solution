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

namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    public partial class SelectPersonControl : UserControl, ISelectPersonView
    {

        private bool _busy;
        public string SearchTerm => txtSearch.Text;
        public bool MessageLabel
        {
            set
            {
                SetMessageVisible(value);
            }
        }

        public int cbSearchById => cbSearchBy.SelectedValue is int id ? id : -1;

        public event EventHandler? SearchRequested;
        public event EventHandler? SearchCriteriaChanged;

        public SelectPersonControl()
        {
            InitializeComponent();
            LoadSearchByComboBox();
            SizeChanged += SelectPersonControl_SizeChanged;
        }

        private void LoadSearchByComboBox()
        {
            var options = new List<ComboBoxItem>
            {
                new ComboBoxItem { Id = 0, Text = "Person Id" },
                new ComboBoxItem { Id = 1, Text = "National No" },
            };

            cbSearchBy.DisplayMember = nameof(ComboBoxItem.Text);
            cbSearchBy.ValueMember = nameof(ComboBoxItem.Id);
            cbSearchBy.DataSource = options;
            cbSearchBy.SelectedValue = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!_busy)
                SearchRequested?.Invoke(this, EventArgs.Empty);
        }

        public void LoadPersonInfo(PersonDto person)
        {
            ArgumentNullException.ThrowIfNull(person);
            personDetailControl1.PersonInitialized(person);
            personDetailControl1.Visible = true;

            SetMessageVisible(false);

            selectionHintHeading.Text = "Applicant found";
            selectionHint.Text =
                "Check the applicant's details before continuing.";
        }
        public void DisplayMessage(string message)
        {
            DisplayMessage(message, MessageType.Error);
        }

        public void DisplayMessage(string message, MessageType type)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                SetMessageVisible(false);
                return;
            }

            var style = type switch
            {
                MessageType.Warning => (
                    Background: Color.FromArgb(255, 251, 235),
                    Border: Color.FromArgb(253, 230, 138),
                    Foreground: Color.FromArgb(146, 64, 14),
                    Icon: "!", Heading: "Check your search"),
                MessageType.Info => (
                    Background: Color.FromArgb(239, 246, 255),
                    Border: Color.FromArgb(191, 219, 254),
                    Foreground: Color.FromArgb(30, 64, 175),
                    Icon: "i", Heading: "Search information"),
                _ => (
                    Background: Color.FromArgb(254, 242, 242),
                    Border: Color.FromArgb(254, 202, 202),
                    Foreground: Color.FromArgb(153, 27, 27),
                    Icon: "!", Heading: "Search unsuccessful")
            };

            messagePanel.FillColor = style.Background;
            messagePanel.BorderColor = style.Border;
            messageIcon.ForeColor = style.Foreground;
            messageIcon.Text = style.Icon;
            messageHeading.ForeColor = style.Foreground;
            messageHeading.Text = style.Heading;
            lblMessage.ForeColor = style.Foreground;
            lblMessage.Text = message;
            messagePanel.AccessibleName = $"{style.Heading}. {message}";

            ResizeMessageBanner();
            SetMessageVisible(true);
        }

        private void SetMessageVisible(bool visible)
        {
            messagePanel.Visible = visible;

            if (!visible)
                AutoScrollPosition = Point.Empty;

            UpdateFeedbackLayout();
        }

        private void MessagePanel_SizeChanged(object? sender, EventArgs e)
        {
            ResizeMessageBanner();
        }

        private void ResizeMessageBanner()
        {
            int textWidth = Math.Max(1, messagePanel.ClientSize.Width - 68);
            var textSize = TextRenderer.MeasureText(
                lblMessage.Text,
                lblMessage.Font,
                new Size(textWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix |
                TextFormatFlags.TextBoxControl);

            int textHeight = Math.Max(20, textSize.Height + 2);
            lblMessage.Size = new Size(textWidth, textHeight);

            int bannerHeight = Math.Max(68, lblMessage.Top + textHeight + 12);
            if (messagePanel.Height != bannerHeight)
                messagePanel.Height = bannerHeight;

            UpdateFeedbackLayout();
        }

        private void SelectPersonControl_SizeChanged(object? sender, EventArgs e)
        {
            UpdateFeedbackLayout();
        }

        private void UpdateFeedbackLayout()
        {
            // Preserve the full person card when present. An empty applicant
            // area can shrink to make room for feedback without scrolling.
            int minimumApplicantHeight = personDetailControl1.Visible
                ? personDetailControl1.Bottom + 4
                : selectionHint.Bottom + 16;

            int feedbackHeight = messagePanel.Visible
                ? messagePanel.Height + messagePanel.Margin.Top
                : 0;

            int availableHeight = ClientSize.Height - searchPanel.Height - feedbackHeight;
            int rowHeight = Math.Max(
                minimumApplicantHeight + applicantPanel.Margin.Top,
                availableHeight);

            if (contentLayout.RowStyles[2].Height != rowHeight)
                contentLayout.RowStyles[2].Height = rowHeight;
        }

        public void ClearPersonInfo()
        {

            personDetailControl1.Visible = false;

            lblMessage.Text = string.Empty;
            SetMessageVisible(false);

            selectionHintHeading.Text = "Find an applicant";
            selectionHint.Text =
                "Search by person ID or national number " +
                "to load the applicant's details.";
        }

        public void SetBusy(bool busy)
        {
            _busy = busy;

            searchPanel.Enabled = !busy;
            SearchButton.Text = busy ? "Searching…" : "Search";
            UseWaitCursor = busy;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_busy)
                return;

            UpdateSearchHint();
            SearchCriteriaChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateSearchHint()
        {
            bool byPersonId = cbSearchById == 0;

            searchCaption.Text = byPersonId
                ? "Person ID"
                : "National number";

            txtSearch.PlaceholderText = byPersonId
                ? "Enter person ID"
                : "Enter national number";
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (!_busy)
                SearchRequested?.Invoke(this, EventArgs.Empty);
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Info
    }
}
