#nullable enable
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.DetainedLicenses
{
    public partial class DetainedLicensesTabControl : UserControl, IDetainedLicensesTabView
    {
        public event EventHandler? SearchOrFilterChanged;
        public event EventHandler<int>? PageRequested;
        public event EventHandler<int>? ViewPersonRequested;
        public event EventHandler<int>? ViewLicenseRequested;
        public event EventHandler<int>? ViewHistoryRequested;
        public event EventHandler<int>? ReleaseDetainedLicenseRequested;
        public event EventHandler? OpenDetainReleaseScreenRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => txtDetainedSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StatusFilterIndex => cbDetainedStatus.SelectedIndex;

        public DetainedLicensesTabControl()
        {
            InitializeComponent();
            ApplicationsUIHelper.Configure(
                DetainedDataGridView,
                detainedPaginationFooter,
                DetainedActionMenu);

            txtDetainedSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtDetainedSearch.IconLeftSize = new Size(16, 16);
            txtDetainedSearch.TextOffset = new Point(0, 0);

            btnDetainShortcut.Image = Properties.Resources.icons8_lock_32;
            btnDetainShortcut.ImageSize = new Size(16, 16);
            btnDetainShortcut.ImageOffset = new Point(-2, 0);

            DetainedShowPerson.Image = Properties.Resources.icons8_driver_48;
            DetainedShowLicense.Image = Properties.Resources.icons8_id_card_30;
            DetainedShowHistory.Image = Properties.Resources.icons8_history_48;
            DetainedReleaseAction.Image = Properties.Resources.icons8_lock_32;

            cbDetainedStatus.SelectedIndex = 0;

            txtDetainedSearch.TextChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            cbDetainedStatus.SelectedIndexChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            btnDetainShortcut.Click += (_, _) => OpenDetainReleaseScreenRequested?.Invoke(this, EventArgs.Empty);
            detainedPaginationFooter.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            DetainedDataGridView.CellMouseDown += OnCellMouseDown;
            DetainedActionMenu.Opening += (_, _) => UpdateMenuState();

            DetainedShowPerson.Click += (_, _) => RaiseIntCellEvent("DetainedPersonId", ViewPersonRequested, "Person record ID is unavailable for this entry.");
            DetainedShowHistory.Click += (_, _) => RaiseIntCellEvent("DetainedPersonId", ViewHistoryRequested, "Person record ID is unavailable for this entry.");
            DetainedShowLicense.Click += (_, _) => RaiseIntCellEvent("DetainedLicenseId", ViewLicenseRequested, null);
            DetainedReleaseAction.Click += (_, _) => RaiseIntCellEvent("DetainedLicenseId", ReleaseDetainedLicenseRequested, null);
        }

        public void DisplayDetainedLicenses(IEnumerable<DetainedLicenseListItemDto> items)
        {
            DetainedDataGridView.Rows.Clear();
            var list = items ?? Array.Empty<DetainedLicenseListItemDto>();

            foreach (var item in list)
            {
                int rowIndex = DetainedDataGridView.Rows.Add();
                var row = DetainedDataGridView.Rows[rowIndex];
                row.Cells["DetainId"].Value = item.DetainId;
                row.Cells["DetainedLicenseId"].Value = item.LicenseId;
                row.Cells["FullName"].Value = item.FullName;
                row.Cells["NationalNo"].Value = item.NationalNo;
                row.Cells["DetainDate"].Value = item.DetainDate;
                row.Cells["FineFees"].Value = item.FineFees;
                row.Cells["Status"].Value = item.IsReleased ? "Released" : "Detained";
                row.Cells["ReleaseDate"].Value = item.ReleaseDate.HasValue ? item.ReleaseDate.Value : "—";
                row.Cells["ReleaseAppId"].Value = item.ReleaseApplicationId.HasValue ? item.ReleaseApplicationId.Value : "—";
                row.Cells["DetainedPersonId"].Value = item.PersonId;
            }

            lblDetainedMessage.Visible = DetainedDataGridView.Rows.Count == 0;
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            detainedPaginationFooter.DisplayPagination(
                pageNumber,
                totalPages,
                totalCount,
                DetainedDataGridView.Rows.Count,
                "detained licenses");
        }

        public void SetLoading(bool isLoading)
        {
            detainedPaginationFooter.SetLoading(isLoading);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(this, message, "Detained Licenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnCellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < DetainedDataGridView.Rows.Count)
                DetainedDataGridView.CurrentCell = DetainedDataGridView.Rows[e.RowIndex].Cells["DetainId"];
        }

        private void UpdateMenuState()
        {
            if (DetainedDataGridView.SelectedRows.Count == 0)
            {
                DetainedReleaseAction.Enabled = false;
                return;
            }

            string status = DetainedDataGridView.SelectedRows[0].Cells["Status"].Value?.ToString() ?? string.Empty;
            DetainedReleaseAction.Enabled = status.Equals("Detained", StringComparison.OrdinalIgnoreCase);
        }

        private void RaiseIntCellEvent(string columnName, EventHandler<int>? handler, string? missingMessage)
        {
            if (DetainedDataGridView.SelectedRows.Count == 0)
                return;

            if (int.TryParse(DetainedDataGridView.SelectedRows[0].Cells[columnName].Value?.ToString(), out int value) && value > 0)
            {
                handler?.Invoke(this, value);
            }
            else if (!string.IsNullOrWhiteSpace(missingMessage))
            {
                DisplayMessage(missingMessage);
            }
        }
    }
}
