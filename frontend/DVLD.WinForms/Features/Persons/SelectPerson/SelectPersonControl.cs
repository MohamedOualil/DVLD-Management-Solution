#nullable enable
using DVLD.Contracts.Persons;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    public partial class SelectPersonControl : UserControl, ISelectPersonView
    {
        private bool _busy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => txtSearch.Text;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MessageLabel
        {
            set
            {
                SetMessageVisible(value);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int cbSearchById => cbSearchBy.SelectedValue is int id ? id : -1;

        public event EventHandler? SearchRequested;
        public event EventHandler? SearchCriteriaChanged;

        public SelectPersonControl()
        {
            InitializeComponent();
            txtSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.TextOffset = new Point(0, 0);
            LoadSearchByComboBox();
            UpdateSearchHint();
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

        public void LoadPersonInfo(PersonResponse person)
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

            var (tone, heading) = type switch
            {
                MessageType.Warning => (HeaderBadgeTone.Warning, "Check your search"),
                MessageType.Info => (HeaderBadgeTone.Info, "Search information"),
                _ => (HeaderBadgeTone.Danger, "Search unsuccessful")
            };

            statusBanner.SetBanner(heading, message, tone);
            statusBanner.AccessibleName = $"{heading}. {message}";
            SetMessageVisible(true);
        }

        private void SetMessageVisible(bool visible)
        {
            statusBanner.Visible = visible;
        }

        public void ClearPersonInfo()
        {
            personDetailControl1.Visible = false;
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

        private void cbSearchBy_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_busy)
                return;

            UpdateSearchHint();
            SearchCriteriaChanged?.Invoke(this, EventArgs.Empty);
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
                ? "PERSON ID"
                : "NATIONAL NUMBER";

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
