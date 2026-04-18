using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.WinForms.Features.Persons
{
    public class PersonService(IApiClient apiClient) : IPesronService
    {
        private readonly IApiClient _apiClient = apiClient;
        public async Task<ApiResponse<PersonDto>> GetPerson(int personId)
        {
            string endpoint = $"Person/{personId}";
            return await _apiClient.GetAsync<PersonDto>(endpoint);
        }
    }
}
