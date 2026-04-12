using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.WinForms.Features.Applications
{
    public class ApplicationsService(IApiClient apiClient) : IApplicationsService
    {
        private readonly IApiClient _apiClient = apiClient;
        public async Task<ApiResponse<PagedResultDto<LocalApplicationsDto>>> GetAllLocalApplicationsAsync(int PageNumber, int PageSize)
        {
            string endpoint = $"LocalDrivingLicenseApplication?pageNumber={PageNumber}&pageSize={PageSize}";
            return await _apiClient.GetAsync<PagedResultDto<LocalApplicationsDto>>(endpoint);
        }
    }
}
