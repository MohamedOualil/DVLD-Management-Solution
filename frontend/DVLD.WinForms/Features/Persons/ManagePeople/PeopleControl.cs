#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    public partial class PeopleControl : UserControl, IPeopleView
    {
        private readonly List<GetAllPersonResponse> _allRows = [];

        public event EventHandler? LoadRequested;
        public event EventHandler<int>? PageRequested;
        public event EventHandler? AddPersonRequested;
        public event EventHandler<int>? ViewPersonRequested;
        public event EventHandler<int>? EditPersonRequested;

        public PeopleControl()
        {
            InitializeComponent();
            filterBar.SetFilterItems("All Genders", "Male", "Female");

            filterBar.SearchChanged += (_, _) => ApplyFilter();
            filterBar.FilterChanged += (_, _) => ApplyFilter();
            filterBar.PrimaryActionClicked += (_, _) => AddPersonRequested?.Invoke(this, EventArgs.Empty);
            paginationBar.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            peopleGrid.CellContentClick += OnGridCellContentClick;
            peopleGrid.CellDoubleClick += OnGridCellDoubleClick;
            peopleGrid.CellPainting += OnGridCellPainting;
            peopleGrid.CellMouseEnter += OnGridCellMouseEnter;
            peopleGrid.CellMouseLeave += OnGridCellMouseLeave;
            peopleGrid.MouseLeave += (_, _) =>
            {
                foreach (DataGridViewRow r in peopleGrid.Rows)
                    r.DefaultCellStyle.BackColor = Color.Empty;
                peopleGrid.Cursor = Cursors.Default;
            };
        }

        private void PeopleControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayPeople(IEnumerable<GetAllPersonResponse> people)
        {
            _allRows.Clear();
            if (people is not null)
                _allRows.AddRange(people);

            ApplyFilter();
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            paginationBar.DisplayPagination(pageNumber, totalPages, totalCount, peopleGrid.Rows.Count, "people");
            filterBar.CountText = $"{totalCount} {(totalCount == 1 ? "person" : "people")}";
        }

        public void SetLoading(bool isLoading)
        {
            paginationBar.SetLoading(isLoading);
            UseWaitCursor = isLoading;
        }

        public void DisplayMessage(string message)
        {
            if (_allRows.Count == 0)
            {
                lblEmptyState.Text = message;
                lblEmptyState.Visible = true;
            }
            else
            {
                MessageBox.Show(this, message, "People Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApplyFilter()
        {
            string term = filterBar.SearchText;
            int genderFilter = filterBar.SelectedFilterIndex; // 0 = All, 1 = Male, 2 = Female

            var filtered = _allRows.Where(p =>
            {
                if (genderFilter == 1 && (Gender)p.Gender != Gender.Male)
                    return false;
                if (genderFilter == 2 && (Gender)p.Gender != Gender.Female)
                    return false;

                if (string.IsNullOrWhiteSpace(term))
                    return true;

                string fullName = BuildFullName(p);
                return fullName.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || p.NationalNo.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || p.Phone.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || (p.Email?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
                    || p.PersonId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            peopleGrid.Rows.Clear();
            foreach (var person in filtered)
            {
                int rowIndex = peopleGrid.Rows.Add();
                var row = peopleGrid.Rows[rowIndex];
                row.Cells["PersonId"].Value = person.PersonId;
                row.Cells["NationalNo"].Value = person.NationalNo;
                row.Cells["FullName"].Value = BuildFullName(person);
                row.Cells["Gender"].Value = ((Gender)person.Gender).ToString();
                row.Cells["DateOfBirth"].Value = person.DateOfBirth;
                row.Cells["Phone"].Value = person.Phone;
                row.Cells["Email"].Value = string.IsNullOrWhiteSpace(person.Email) ? "—" : person.Email;
            }

            lblEmptyState.Text = filtered.Count == 0
                ? (_allRows.Count == 0 ? "No people records found." : "No people match the current search filter.")
                : string.Empty;
            lblEmptyState.Visible = filtered.Count == 0;
            peopleGrid.ClearSelection();
        }

        private void OnGridCellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string colName = peopleGrid.Columns[e.ColumnIndex].Name;
            if (colName != "ViewCard" && colName != "EditPerson")
                return;

            if (!int.TryParse(peopleGrid.Rows[e.RowIndex].Cells["PersonId"].Value?.ToString(), out int personId) || personId <= 0)
                return;

            if (colName == "ViewCard")
                ViewPersonRequested?.Invoke(this, personId);
            else
                EditPersonRequested?.Invoke(this, personId);
        }

        private void OnGridCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (int.TryParse(peopleGrid.Rows[e.RowIndex].Cells["PersonId"].Value?.ToString(), out int personId) && personId > 0)
                ViewPersonRequested?.Invoke(this, personId);
        }

        private void OnGridCellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= peopleGrid.Rows.Count)
                return;

            peopleGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 250);
            peopleGrid.Cursor = Cursors.Hand;
        }

        private void OnGridCellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= peopleGrid.Rows.Count)
                return;

            peopleGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            peopleGrid.Cursor = Cursors.Default;
        }

        private void OnGridCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (peopleGrid.Columns[e.ColumnIndex].Name == "FullName")
                DataGridViewUIHelper.DrawAvatarAndName(e);
        }

        private static string BuildFullName(GetAllPersonResponse p) =>
            string.Join(" ", new[] { p.FirstName, p.SecondName, p.ThirdName, p.LastName }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
    }
}
