using DVLD.WinForms.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private Form? _form;

        private Control? _mainContentPanel;

        // This holds the memory for the CURRENT page. 
        // When we switch pages, we destroy this scope to free up RAM!
        private IServiceScope? _currentPageScope;
        public void CloseCurrentForm(Form currentForm)
        {
            currentForm?.Close();
        }

        public void HideCurrentForm(Form currentForm)
        {
            currentForm?.Hide();
        }

        // ------------------------------------------------------------------
        //  Navigation history
        // ------------------------------------------------------------------
        // Pages are disposed when we leave them (to free RAM), so we can't keep
        // the old controls in the stack. Instead we store a "recipe" (an Action)
        // that knows how to rebuild the page again (same presenter + same setup).
        private sealed record NavigationEntry(Type PresenterType, Action Show);

        private readonly Stack<NavigationEntry> _backStack = new();
        private readonly Stack<NavigationEntry> _forwardStack = new();
        private NavigationEntry? _current;

        public bool CanGoBack => _backStack.Count > 0;
        public bool CanGoForward => _forwardStack.Count > 0;
        public Type? CurrentPresenterType => _current?.PresenterType;

        public bool HasChanges { get; set; }

        public event EventHandler? HistoryChanged;

        /// <summary>
        /// Prompts the user if there are unsaved changes before navigating away.
        /// Returns true if navigation can proceed; false if canceled.
        /// </summary>
        private bool CanNavigateAway()
        {
            if (!HasChanges)
                return true;

            var owner = _mainContentPanel?.FindForm() ?? _form;
            var result = MessageBox.Show(
                owner,
                "You have unsaved changes. Do you want to leave without saving?",
                "Unsaved Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                HasChanges = false; // User discarded changes
                return true;
            }

            return false; // User canceled, stay on the current page
        }

        public void NavigateTo<TPresenter, TView>(Action<TPresenter> setup = null) where TPresenter
            : BasePresenter<TView> where TView : class
        {
            // 1. If already on this exact page without extra parameters, ignore duplicate clicks
            if (_current != null && _current.PresenterType == typeof(TPresenter) && setup == null)
            {
                return;
            }

            // 2. Check for unsaved changes before leaving the current page
            if (!CanNavigateAway())
            {
                return;
            }

            var entry = new NavigationEntry(
                typeof(TPresenter),
                () => ShowPage<TPresenter, TView>(setup));

            // Show first: if building the page throws, history stays untouched.
            entry.Show();

            // 3. Current page goes to the Back stack (preventing consecutive duplicates)
            if (_current != null && _current.PresenterType != entry.PresenterType)
            {
                if (_backStack.Count == 0 || _backStack.Peek().PresenterType != _current.PresenterType)
                {
                    _backStack.Push(_current);
                }
            }

            _current = entry;

            // ...and a NEW navigation always kills the Forward history (like a browser).
            _forwardStack.Clear();

            OnHistoryChanged();
        }

        public void GoBack()
        {
            if (!CanGoBack || _current == null) return;
            if (!CanNavigateAway()) return;

            var target = _backStack.Peek();
            target.Show();

            _backStack.Pop();
            _forwardStack.Push(_current);
            _current = target;

            OnHistoryChanged();
        }

        public void GoForward()
        {
            if (!CanGoForward || _current == null) return;
            if (!CanNavigateAway()) return;

            var target = _forwardStack.Peek();
            target.Show();

            _forwardStack.Pop();
            _backStack.Push(_current);
            _current = target;

            OnHistoryChanged();
        }

        public void Refresh()
        {
            if (!CanNavigateAway()) return;

            // Rebuild the current page with a fresh scope / presenter (reloads data).
            _current?.Show();
        }

        public void ClearHistory()
        {
            _backStack.Clear();
            _forwardStack.Clear();
            _current = null;
            OnHistoryChanged();
        }

        private void OnHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>Builds and displays a page. Does NOT touch the history.</summary>
        private void ShowPage<TPresenter, TView>(Action<TPresenter>? setup) where TPresenter
            : BasePresenter<TView> where TView : class
        {
            if (_mainContentPanel == null)
            {
                throw new InvalidOperationException("Main content panel is not set. Call SetMainContentPanel first.");
            }

            // Copy to an array first: disposing a control removes it from the
            // Controls collection, which breaks a foreach over that collection.
            foreach (Control oldControl in _mainContentPanel.Controls.Cast<Control>().ToArray())
            {
                oldControl.Dispose();
            }

            _mainContentPanel.Controls.Clear();

            _currentPageScope?.Dispose();

            _currentPageScope = _serviceProvider.CreateScope();

            var presenter = _currentPageScope.ServiceProvider.GetRequiredService<TPresenter>();

            setup?.Invoke(presenter);

            if (presenter.ViewInstance is Control control)
            {
                control.Dock = DockStyle.Fill;

                _mainContentPanel.Controls.Add(control);

                // Fresh page loaded: reset dirty state
                HasChanges = false;
            }
            else
            {
                throw new InvalidOperationException("The View must be a WinForms Control.");
            }


        }


        public void SetMainContentPanel(Control panel)
        {
            _mainContentPanel = panel;
            ClearHistory(); // new shell (e.g. after re-login) => start with empty history
        }

        public void SetMainForm(Form mainForm)
        {
            _form = mainForm;
        }

        public void ShowChildForm<TForm>() where TForm : Form
        {
            throw new NotImplementedException();
        }

        public void ShowDialog<TForm>(Action<TForm>? setup = null) where TForm : Form
        {
            using var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<TForm>();

            setup?.Invoke(form);

            var owner = _mainContentPanel?.FindForm() ?? _form;
            if (owner is { IsDisposed: false, Visible: true })
                form.ShowDialog(owner);
            else
                form.ShowDialog();
        }

        public void ShowForm<TForm>() where TForm : Form
        {
            var form = _serviceProvider.GetRequiredService<TForm>();
            form.ShowDialog();
        }
    }
}
