using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private Form _form;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
        }

        public void CloseCurrentForm(Form currentForm)
        {
            currentForm?.Close();
        }

        public void HideCurrentForm(Form currentForm)
        {
            currentForm?.Hide();
        }

        public void SetMainForm(Form mainForm)
        {
            _form = mainForm;
        }

        public void ShowChildForm<TForm>() where TForm : Form
        {
            throw new NotImplementedException();
        }

        public void ShowDialog<TForm>() where TForm : Form
        {
            throw new NotImplementedException();
        }

        public void ShowForm<TForm>() where TForm : Form
        {
            var form = _serviceProvider.GetRequiredService<TForm>();
            form.ShowDialog();
        }
    }
}
