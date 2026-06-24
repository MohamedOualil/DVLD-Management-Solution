using DVLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        TokenResponse Generate(User user);
    }
}
