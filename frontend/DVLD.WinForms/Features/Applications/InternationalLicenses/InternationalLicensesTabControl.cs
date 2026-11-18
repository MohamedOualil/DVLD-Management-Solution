#nullable enable
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.InternationalLicenses
{
    public partial class InternationalLicensesTabControl : UserControl, IInternationalLicensesTabView
    {
        public event EventHandler? SearchOrFilterChanged;
        public event EventHandler<int>? PageRequested;
        public event EventHandler<int>? ViewPersonRequested;
        public event EventHandler<int>? ViewLicenseRequested;
        public event EventHandler<int>? ViewHistoryRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => txtIntlSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StatusFilterIndex => cbIntlStatus.SelectedIndex;

        public InternationalLicensesTabControl()
        {
            InitializeComponent();
            ApplicationsUIHelper.Configure(
                IntlDataGridView,
                intlPaginationFooter,
                IntlActionMenu);

            txtIntlSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtIntlSearch.IconLeftSize = new Size(16, 16);
            txtIntlSearch.TextOffset = new Point(0, 0);

            IntlShowPerson.Image = Properties.Resources.icons8_driver_48;
            IntlShowLicense.Image = Properties.Resources.icons8_id_card_30;
            IntlShowHistory.Image = Properties.Resources.icons8_history_48;

            cbIntlStatus.SelectedIndex = 0;

            txtIntlSearch.TextChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            cbIntlStatus.SelectedIndexChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            intlPaginationFooter.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            IntlDataGridView.CellMouseDown += OnCellMouseDown;

            IntlShowPerson.Click += (_, _) => RaiseIntCellEvent("IntlPersonId", ViewPersonRequested, "Person record ID is unavailable for this entry.");
            IntlShowHistory.Click += (_, _) => RaiseIntCellEvent("IntlPersonId", ViewHistoryRequested, "Person record ID is unavailable for this entry.");
            IntlShowLicense.Click += (_, _) => RaiseIntCellEvent("IntlLocalLicenseId", ViewLicenseRequested, null);
        }

        public void DisplayInternationalLicenses(IEnumerable<InternationalLicenseListItemDto> items)
        {
            IntlDataGridView.Rows.Clear();
            var list = items ?? Array.Empty<InternationalLicenseListItemDto>();

            foreach (var item in list)
            {
                int rowIndex = IntlDataGridView.Rows.Add();
                var row = IntlDataGridView.Rows[rowIndex];
                row.Cells["IntlLicenseId"].Value = item.InternationalLicenseId;
                row.Cells["FullName"].Value = item.FullName;
                row.Cells["NationalNo"].Value = item.NationalNo;
                row.Cells["IntlLocalLicenseId"].Value = item.LocalLicenseId;
                row.Cells["IntlApplicationId"].Value = item.ApplicationId;
                row.Cells["IntlIssueDate"].Value = item.IssueDate;
                row.Cells["IntlExpirationDate"].Value = item.ExpirationDate;
                row.Cells["Status"].Value = item.IsActive && item.ExpirationDate.Date >= DateTime.Today ? "Active" : "Expired";
                row.Cells["IntlPersonId"].Value = item.PersonId;
            }

            lblIntlMessage.Visible = IntlDataGridView.Rows.Count == 0;
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            intlPaginationFooter.DisplayPagination(
                pageNumber,
                totalPages,
                totalCount,
                IntlDataGridView.Rows.Count,
                "international licenses");
        }

        public void SetLoading(bool isLoading)
        {
            intlPaginationFooter.SetLoading(isLoading);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(this, message, "International Licenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnCellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < IntlDataGridView.Rows.Count)
                IntlDataGridView.CurrentCell = IntlDataGridView.Rows[e.RowIndex].Cells["IntlLicenseId"];
        }

        private void RaiseIntCellEvent(string columnName, EventHandler<int>? handler, string? missingMessage)
        {
            if (IntlDataGridView.SelectedRows.Count == 0)
                return;

            if (int.TryParse(IntlDataGridView.SelectedRows[0].Cells[columnName].Value?.ToString(), out int value) && value > 0)
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
