#nullable enable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class PaginationBarControl : UserControl
    {
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _totalCount;
        private string _itemLabel = "records";
        private bool _isLoading;

        public event EventHandler<int>? PageRequested;

        public PaginationBarControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();

            btnPrevious.Click += (_, _) =>
            {
                if (!_isLoading && _currentPage > 1)
                    PageRequested?.Invoke(this, _currentPage - 1);
            };

            btnNext.Click += (_, _) =>
            {
                if (!_isLoading && _currentPage < _totalPages)
                    PageRequested?.Invoke(this, _currentPage + 1);
            };
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPage => _currentPage;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalPages => _totalPages;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalCount => _totalCount;

        [Category("Appearance")]
        [DefaultValue("records")]
        public string ItemLabel
        {
            get => _itemLabel;
            set
            {
                _itemLabel = string.IsNullOrWhiteSpace(value) ? "records" : value.Trim();
                UpdateDisplay();
            }
        }

        public void DisplayPagination(
            int pageNumber,
            int totalPages,
            int totalCount,
            int? visibleCount = null,
            string? itemLabel = null)
        {
            _currentPage = Math.Max(1, pageNumber);
            _totalPages = Math.Max(1, totalPages);
            _totalCount = Math.Max(0, totalCount);

            if (!string.IsNullOrWhiteSpace(itemLabel))
                _itemLabel = itemLabel.Trim();

            UpdateDisplay(visibleCount);
        }

        public void SetLoading(bool isLoading)
        {
            _isLoading = isLoading;
            btnPrevious.Enabled = !isLoading && _currentPage > 1;
            btnNext.Enabled = !isLoading && _currentPage < _totalPages;

            if (isLoading)
                lblPaginationSummary.Text = $"Loading {_itemLabel}…";
            else
                UpdateDisplay();
        }

        private void UpdateDisplay(int? visibleCount = null)
        {
            lblCurrentPage.Text = _currentPage.ToString();

            if (visibleCount.HasValue)
            {
                lblPaginationSummary.Text =
                    $"Showing {visibleCount.Value} of {_totalCount} {_itemLabel}  •  Page {_currentPage} of {_totalPages}";
            }
            else if (_totalCount == 0)
            {
                lblPaginationSummary.Text = $"Showing 0 of 0 {_itemLabel}";
            }
            else
            {
                lblPaginationSummary.Text =
                    $"Page {_currentPage} of {_totalPages}  •  {_totalCount} {_itemLabel}";
            }

            btnPrevious.Enabled = !_isLoading && _currentPage > 1;
            btnNext.Enabled = !_isLoading && _currentPage < _totalPages;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var borderPen = new Pen(Color.FromArgb(226, 232, 240), 1);
            e.Graphics.DrawLine(borderPen, 0, 0, Width, 0);
        }
    }
}
