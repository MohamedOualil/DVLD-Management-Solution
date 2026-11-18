#nullable enable
using DVLD.Contracts.Persons;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons
{
    public partial class PersonCardForm : Form
    {
        public PersonCardForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            closeButton.Click += (_, _) => Close();

            ModalDialogShellHelper.Attach(
                this,
                borderRadius: 13f,
                onEscape: Close,
                headerPanel,
                headerAccentBar,
                headerDivider,
                footerPanel,
                footerDivider);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Detail.PersonDetailControl PersonCard => personDetailControl1;

        public void DisplayPerson(PersonResponse personDto)
        {
            ArgumentNullException.ThrowIfNull(personDto);

            personDetailControl1.PersonInitialized(personDto);
            subtitleLabel.Text = $"National No: {personDto.NationalNo}  •  Person ID #{personDto.PersonId}";
            recordStatusBadge.Text = "● Verified Profile";
        }
    }
}
