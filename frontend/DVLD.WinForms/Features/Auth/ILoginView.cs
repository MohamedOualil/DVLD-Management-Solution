using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        void ShowError (string message);
        void ShowLoading (bool isLoading);

        event EventHandler<EventArgs> OnLogin;
    }
}
