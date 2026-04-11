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

        private Control _mainContentPanel;

        // This holds the memory for the CURRENT page. 
        // When we switch pages, we destroy this scope to free up RAM!
        private IServiceScope _currentPageScope;

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

        public void NavigateTo<TControl>() where TControl : UserControl
        {
            if (_mainContentPanel == null)
            {
                throw new InvalidOperationException("Main content panel is not set. Call SetMainContentPanel first.");
            }

            foreach (Control oldControl in _mainContentPanel.Controls)
            {
                oldControl.Dispose();
            }
            _mainContentPanel.Controls.Clear();

            _currentPageScope?.Dispose();

            _currentPageScope = _serviceProvider.CreateScope();

            var control = _currentPageScope.ServiceProvider.GetRequiredService<TControl>();


            control.Dock = DockStyle.Fill;
            
            _mainContentPanel.Controls.Add(control);
        }

        public void SetMainContentPanel(Control panel)
        {
            _mainContentPanel = panel;
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
