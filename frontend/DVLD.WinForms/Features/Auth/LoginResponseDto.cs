using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class LoginResponseDto
    {
        public required string Username { get; set; } 
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public required string Role { get; set; }
        public bool IsActive { get; set; }
        public required string Token { get; set; } 
    }
}
