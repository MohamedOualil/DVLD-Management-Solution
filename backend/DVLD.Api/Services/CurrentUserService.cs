using DVLD.Application.Abstractions;
using System.Security.Claims;

namespace DVLD.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _http;

        public CurrentUserService(IHttpContextAccessor http)
        {
            _http = http;
        }
        public int? UserId =>
            int.TryParse(
            _http.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
            out var id) ? id : null;


        public string? UserRole => _http.HttpContext?.User.FindFirstValue(ClaimTypes.Role);

        public string? IpAddress => _http.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";


        public string? UserName => _http.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

        public string? DeviceId => _http.HttpContext?.Request?.Headers["X-Device-Id"].FirstOrDefault();

        public string? DeviceInfo => _http.HttpContext?.Request?.Headers["X-Device-Info"].FirstOrDefault();

    }
    
}
