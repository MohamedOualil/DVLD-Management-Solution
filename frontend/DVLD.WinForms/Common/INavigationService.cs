using DVLD.WinForms.Shared;
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

        void HideCurrentForm(Form currentForm);

        void CloseCurrentForm(Form currentForm);

        void SetMainContentPanel(Control panel);

        void NavigateTo<TPresenter, TView>() where TPresenter : BasePresenter<TView> where TView : class;
    }
}
