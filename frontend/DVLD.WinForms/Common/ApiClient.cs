using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppSession _session;

        private const string BaseUrl = "https://localhost:7261/api/";

        public ApiClient(AppSession session,HttpClient httpClient)
        {
            _session = session;
            _httpClient = httpClient;

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(BaseUrl);
            }
        }


        private void AttachToken(HttpRequestMessage request)
        {
            if (_session != null && !string.IsNullOrEmpty(_session.CurrentToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _session.CurrentToken);
            }
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            AttachToken(request);

            var response = await _httpClient.SendAsync(request);

            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = JsonContent.Create(data)
            };
            AttachToken(request);

            var response = await _httpClient.SendAsync(request);
            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
            {
                Content = JsonContent.Create(data)
            };
            AttachToken(request);

            var response = await _httpClient.SendAsync(request);
            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
            AttachToken(request);

            var response = await _httpClient.SendAsync(request);
            return await ProcessResponse<T>(response);
        }

        private async Task<ApiResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new ApiResponse<T>
                {
                    IsSuccess = false,
                    Error = "Your session has expired or you do not have permission. Please log in again."
                };
            }

            try
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<T>>();

                if (apiResponse != null)
                {
                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    IsSuccess = false,
                    Error = $"An error occurred reading the data: {ex.Message}"
                };
            }

            return new ApiResponse<T>
            {
                IsSuccess = false,
                Error = "An unknown error occurred while communicating with the server."
            };
        }
    }
}
