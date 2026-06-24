using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Authentication
{
    public record TokenResponse(
                    string AccessToken,
                    string RefreshToken,
                    DateTime RefreshTokenExpiresAt);
}
