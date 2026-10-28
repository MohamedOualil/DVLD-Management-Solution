using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons
{
    public partial class PersonCardForm : Form
    {
        public PersonCardForm()
        {
            InitializeComponent();
        }

        public void DisplayPerson(PersonDto personDto)
        {
            ArgumentNullException.ThrowIfNull(personDto);
            personDetailControl1.PersonInitialized(personDto);
        }
    }
}
