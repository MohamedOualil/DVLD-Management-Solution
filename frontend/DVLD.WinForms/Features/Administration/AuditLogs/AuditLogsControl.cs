#nullable enable
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Administration.AuditLogs
{
    public partial class AuditLogsControl : UserControl, IAuditLogsView
    {
        public event EventHandler? LoadRequested;
        public event EventHandler<int>? PageRequested;
        public event EventHandler? SearchOrFilterChanged;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => filterBar.SearchText;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StatusFilter => filterBar.SelectedFilterIndex switch
        {
            1 => "Success",
            2 => "Warning",
            3 => "Failed",
            _ => "All"
        };

        public AuditLogsControl()
        {
            InitializeComponent();
            filterBar.SetFilterItems("All Outcomes", "Success", "Warning", "Failed");

            filterBar.SearchChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            filterBar.FilterChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            filterBar.PrimaryActionClicked += (_, _) => LoadRequested?.Invoke(this, EventArgs.Empty);
            paginationBar.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            auditGrid.SelectionChanged += OnSelectionChanged;
            auditGrid.CellFormatting += OnCellFormatting;
            auditGrid.CellPainting += OnCellPainting;
        }

        private void AuditLogsControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayAuditLogs(IEnumerable<AuditLogItemDto> logs)
        {
            var items = logs?.ToList() ?? [];
            auditGrid.Rows.Clear();

            foreach (var entry in items)
            {
                int rowIndex = auditGrid.Rows.Add();
                var row = auditGrid.Rows[rowIndex];
                row.Tag = entry;
                row.Cells["LogId"].Value = $"#{entry.LogId}";
                row.Cells["Timestamp"].Value = entry.Timestamp;
                row.Cells["Username"].Value = entry.Username;
                row.Cells["Role"].Value = entry.Role;
                row.Cells["Operation"].Value = entry.Operation;
                row.Cells["TargetEntity"].Value = entry.TargetEntity;
                row.Cells["Status"].Value = entry.Status;
            }

            lblEmptyState.Visible = auditGrid.Rows.Count == 0;
            if (auditGrid.Rows.Count > 0)
                auditGrid.Rows[0].Selected = true;
            else
                lblDetailValue.Text = "No audit log entries match the current filter.";
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            paginationBar.DisplayPagination(pageNumber, totalPages, totalCount, auditGrid.Rows.Count, "events");
            filterBar.CountText = $"{totalCount} {(totalCount == 1 ? "event" : "events")}";
        }

        public void SetSourceBanner(string title, string description, HeaderBadgeTone tone)
        {
            statusBanner.SetBanner(title, description, tone);
        }

        public void SetLoading(bool isLoading)
        {
            paginationBar.SetLoading(isLoading);
            UseWaitCursor = isLoading;
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(this, message, "System Audit Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnSelectionChanged(object? sender, EventArgs e)
        {
            if (auditGrid.SelectedRows.Count == 0)
                return;

            if (auditGrid.SelectedRows[0].Tag is AuditLogItemDto item)
            {
                lblDetailValue.Text = string.IsNullOrWhiteSpace(item.Details)
                    ? $"{item.Operation} on {item.TargetEntity} by {item.Username} ({item.Status})"
                    : item.Details;
            }
        }

        private void OnCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || auditGrid.Columns[e.ColumnIndex].Name != "Status")
                return;

            string status = e.Value?.ToString() ?? string.Empty;
            if (status.Equals("Success", StringComparison.OrdinalIgnoreCase))
                e.CellStyle!.ForeColor = Color.FromArgb(21, 128, 61);
            else if (status.Equals("Warning", StringComparison.OrdinalIgnoreCase))
                e.CellStyle!.ForeColor = Color.FromArgb(180, 83, 9);
            else if (status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                e.CellStyle!.ForeColor = Color.FromArgb(185, 28, 28);
            else
                e.CellStyle!.ForeColor = Color.FromArgb(71, 85, 105);
        }

        private void OnCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (auditGrid.Columns[e.ColumnIndex].Name == "Status")
                DataGridViewUIHelper.DrawStatusBadge(e);
        }
    }
}
