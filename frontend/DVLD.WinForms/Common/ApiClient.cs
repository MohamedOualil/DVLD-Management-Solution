using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        private static async Task<ApiResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new ApiResponse<T>
                    {
                        IsSuccess = true,
                        Data = default 
                    };
                }

                return new ApiResponse<T>
                {
                    IsSuccess = true,
                    Data = JsonConvert.DeserializeObject<T>(json)
                };
            }

            ErrorResponse? errorResponse = null;

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    errorResponse = CreateFallbackError(response.StatusCode, "The server returned an empty error response.");
                }
                else
                {
                    errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(json);
                }
            }
            catch
            {
                errorResponse = CreateFallbackError(response.StatusCode, json);
            }

            return new ApiResponse<T>
            {
                IsSuccess = false,
                Error = errorResponse
            };
        }



        private static ErrorResponse CreateFallbackError(System.Net.HttpStatusCode statusCode, string message)
        {
            return new ErrorResponse
            {
                Title = "Error",
                Status = (int)statusCode,
                Errors = new List<ErrorDetail>
                {
                    new ErrorDetail { Code = "Unknown", Message = message }
                }
            };
        }

    }
}
