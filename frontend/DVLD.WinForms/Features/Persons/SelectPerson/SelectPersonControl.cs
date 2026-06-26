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
    public partial class SelectPersonControl : UserControl , ISelectPersonView
    {
        public string SearchTerm => txtSearch.Text;
        public bool MessageLabel
        {
            set
            {
                lblMessage.Visible = value;
            }
        }

        public int cbSearchById => this.cbSearchBy.SelectedIndex;

        public event EventHandler SearchRequested;
        public SelectPersonControl()
        {
            InitializeComponent();
            LoadSearchByComboBox();
        }

        private void LoadSearchByComboBox()
        {
            var statuses = new List<ComboBoxItem>
            {
                new ComboBoxItem { Id = 0, Text = "Person Id" },
                new ComboBoxItem { Id = 1, Text = "National No" },
            };
            cbSearchBy.DataSource = statuses;
            cbSearchBy.DisplayMember = "Text";
            cbSearchBy.ValueMember = "Id";
            cbSearchBy.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }

        public void LoadPersonInfo(PersonDto personDto)
        {
            personDetailControl1.PersonInitialized(personDto);
        }
        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }
    }
}
