using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class AppSession
    {
        public string CurrentToken { get; set; }

        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentToken);

        public bool IsAdmin => Role == "Admin";

        public void Logout()
        {
            CurrentToken = string.Empty;
            UserId = 0;
            PersonId = 0;
            Username = string.Empty;
            Role = string.Empty;
        }
    }
}
