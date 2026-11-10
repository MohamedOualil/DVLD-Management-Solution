using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
        void ShowError(string message);
        void ShowLoading(bool isLoading);

        event EventHandler<EventArgs>? OnLogin;
        event EventHandler? OnViewLoaded;
    }
}
