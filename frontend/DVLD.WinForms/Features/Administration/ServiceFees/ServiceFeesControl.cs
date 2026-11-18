#nullable enable
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Administration.ServiceFees
{
    public partial class ServiceFeesControl : UserControl, IServiceFeesView
    {
        private readonly List<ServiceFeeItemDto> _allItems = [];
        private ServiceFeeItemDto? _selectedOriginal;
        private bool _suppressEditorSignals;

        public event EventHandler? LoadRequested;
        public event EventHandler<(int Id, FeeCategory Category)>? FeeSelected;
        public event EventHandler? SaveRequested;
        public event EventHandler? ResetEditorRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FeeTitleInput => txtFeeTitle.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FeeAmountInput => txtFeeAmount.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FeeDescriptionInput => txtFeeDescription.Text.Trim();

        public ServiceFeesControl()
        {
            InitializeComponent();
            txtSearchFee.IconLeft = Properties.Resources.icons8_search_32;
            txtSearchFee.IconLeftSize = new Size(16, 16);
            txtSearchFee.TextOffset = new Point(0, 0);
            cmbCategoryFilter.SelectedIndex = 0;

            txtSearchFee.TextChanged += (_, _) => ApplyFilter();
            cmbCategoryFilter.SelectedIndexChanged += (_, _) => ApplyFilter();
            feesGrid.SelectionChanged += OnGridSelectionChanged;
            txtFeeTitle.TextChanged += (_, _) => EvaluateDirtyState();
            txtFeeAmount.TextChanged += (_, _) => EvaluateDirtyState();
            txtFeeDescription.TextChanged += (_, _) => EvaluateDirtyState();

            pageActionFooter.PrimaryActionRequested += (_, _) => SaveRequested?.Invoke(this, EventArgs.Empty);
            pageActionFooter.SecondaryActionRequested += (_, _) => ResetEditorRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ServiceFeesControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayFees(IEnumerable<ServiceFeeItemDto> fees)
        {
            _allItems.Clear();
            if (fees is not null)
                _allItems.AddRange(fees);

            ApplyFilter(_selectedOriginal?.Id, _selectedOriginal?.Category);
        }

        public void PopulateEditor(ServiceFeeItemDto item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _selectedOriginal = item;
            _suppressEditorSignals = true;
            try
            {
                btnCodePill.Text = item.CodeLabel;
                btnCodePill.FillColor = item.Category == FeeCategory.ApplicationService
                    ? Color.FromArgb(240, 253, 250)
                    : Color.FromArgb(245, 243, 255);
                btnCodePill.BorderColor = item.Category == FeeCategory.ApplicationService
                    ? Color.FromArgb(153, 246, 228)
                    : Color.FromArgb(221, 214, 254);
                btnCodePill.ForeColor = item.Category == FeeCategory.ApplicationService
                    ? Color.FromArgb(15, 118, 110)
                    : Color.FromArgb(109, 40, 217);

                lblCategoryValue.Text = item.CategoryLabel;
                txtFeeTitle.Text = item.Title;
                txtFeeAmount.Text = item.Fees.ToString("0.00", CultureInfo.InvariantCulture);
                txtFeeDescription.Text = item.Description;

                txtFeeTitle.Enabled = true;
                txtFeeAmount.Enabled = true;
                txtFeeDescription.Enabled = true;
            }
            finally
            {
                _suppressEditorSignals = false;
            }

            SetEditorState(hasSelection: true, isDirty: false, isSaving: false, $"Editing {item.CodeLabel} — modify title, fee, or description and click Save Fee Changes.");
        }

        public void SetBanner(string title, string description, HeaderBadgeTone tone)
        {
            statusBanner.SetBanner(title, description, tone);
        }

        public void SetEditorState(bool hasSelection, bool isDirty, bool isSaving, string hint)
        {
            txtFeeTitle.Enabled = hasSelection && !isSaving;
            txtFeeAmount.Enabled = hasSelection && !isSaving;
            txtFeeDescription.Enabled = hasSelection && !isSaving;

            pageActionFooter.SetBusy(isSaving, "Saving…");
            if (!isSaving)
            {
                pageActionFooter.SetState(hasSelection && isDirty, hint);
            }
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(this, message, "Service Fees & Exam Types", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyFilter(int? selectId = null, FeeCategory? selectCategory = null)
        {
            string term = txtSearchFee.Text.Trim();
            int filterIdx = cmbCategoryFilter.SelectedIndex; // 0=All, 1=Service, 2=Exam

            var filtered = _allItems.Where(item =>
            {
                if (filterIdx == 1 && item.Category != FeeCategory.ApplicationService)
                    return false;
                if (filterIdx == 2 && item.Category != FeeCategory.TestExam)
                    return false;

                if (string.IsNullOrWhiteSpace(term))
                    return true;

                return item.Title.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || item.CodeLabel.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || item.CategoryLabel.Contains(term, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            feesGrid.SelectionChanged -= OnGridSelectionChanged;
            try
            {
                feesGrid.Rows.Clear();
                DataGridViewRow? toSelect = null;

                foreach (var item in filtered)
                {
                    int rowIndex = feesGrid.Rows.Add();
                    var row = feesGrid.Rows[rowIndex];
                    row.Tag = item;
                    row.Cells["Code"].Value = item.CodeLabel;
                    row.Cells["Category"].Value = item.CategoryLabel;
                    row.Cells["Title"].Value = item.Title;
                    row.Cells["Fee"].Value = item.Fees;

                    if (selectId.HasValue && selectCategory.HasValue &&
                        item.Id == selectId.Value && item.Category == selectCategory.Value)
                    {
                        toSelect = row;
                    }
                }

                if (toSelect is null && feesGrid.Rows.Count > 0)
                    toSelect = feesGrid.Rows[0];

                if (toSelect is not null)
                    toSelect.Selected = true;
            }
            finally
            {
                feesGrid.SelectionChanged += OnGridSelectionChanged;
            }

            if (feesGrid.SelectedRows.Count > 0 && feesGrid.SelectedRows[0].Tag is ServiceFeeItemDto selected)
            {
                FeeSelected?.Invoke(this, (selected.Id, selected.Category));
            }
        }

        private void OnGridSelectionChanged(object? sender, EventArgs e)
        {
            if (feesGrid.SelectedRows.Count == 0)
                return;

            if (feesGrid.SelectedRows[0].Tag is ServiceFeeItemDto item)
                FeeSelected?.Invoke(this, (item.Id, item.Category));
        }

        private void EvaluateDirtyState()
        {
            if (_suppressEditorSignals || _selectedOriginal is null)
                return;

            bool titleChanged = !string.Equals(FeeTitleInput, _selectedOriginal.Title, StringComparison.Ordinal);
            bool descChanged = !string.Equals(FeeDescriptionInput, _selectedOriginal.Description, StringComparison.Ordinal);
            bool feeChanged = !decimal.TryParse(FeeAmountInput, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedFee)
                || parsedFee != _selectedOriginal.Fees;

            bool dirty = titleChanged || descChanged || feeChanged;
            SetEditorState(
                hasSelection: true,
                isDirty: dirty,
                isSaving: false,
                dirty
                    ? $"Unsaved changes for {_selectedOriginal.CodeLabel} — click Save Fee Changes to apply."
                    : $"Editing {_selectedOriginal.CodeLabel} — modify title, fee, or description and click Save Fee Changes.");
        }
    }
}
