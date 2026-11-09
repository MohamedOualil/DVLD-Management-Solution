using System.Security.Claims;
using DVLD.Application.Abstractions;
using static System.Net.WebRequestMethods;

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


        public string? UserName => _http.HttpContext?.User.FindFirstValue(ClaimTypes.Name);


    }

}
