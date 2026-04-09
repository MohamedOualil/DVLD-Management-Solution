using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public interface INavigationService
    {
        void ShowForm<TForm>() where TForm : Form;
        void ShowDialog<TForm>() where TForm : Form;
        void SetMainForm(Form mainForm);
        void ShowChildForm<TForm>() where TForm : Form;
    }
}
