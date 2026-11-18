#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Drivers;
using DVLD.WinForms.Common;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Drivers
{
    public interface IDriversService
    {
        Task<ApiResponse<PagedList<DriversListResponse>>> GetDriversAsync(int pageNumber, int pageSize);
    }
}
