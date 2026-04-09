using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class LoginResponseDto
    {
        public string Username { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
