using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsService
    {
        Task<ApiResponse<PagedResultDto<LocalApplicationsDto>>> GetAllLocalApplicationsAsync(
            int PageNumber, int PageSize);
    }
}
