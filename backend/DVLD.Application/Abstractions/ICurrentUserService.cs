using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        string? UserName { get; }
        string? UserRole { get; }
        string? DeviceId { get; }
        string? DeviceInfo { get; }
        string? IpAddress { get; }
    }
}
