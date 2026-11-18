#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Drivers;
using DVLD.WinForms.Common;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Drivers
{
    public class DriversService(IApiClient apiClient) : IDriversService
    {
        public Task<ApiResponse<PagedList<DriversListResponse>>> GetDriversAsync(int pageNumber, int pageSize)
            => apiClient.GetAsync<PagedList<DriversListResponse>>($"Drivers?pageNumber={pageNumber}&pageSize={pageSize}");
    }
}
