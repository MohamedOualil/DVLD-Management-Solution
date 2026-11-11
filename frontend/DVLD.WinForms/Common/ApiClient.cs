using DVLD.Contracts.Auth;
using DVLD.WinForms.Features.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppSession _session;
        private readonly IRefreshTokenService _refreshTokenService;

        public const string DockerUrl = "http://localhost:5000/api/";
        public const string LocalUrl = "https://localhost:7261/api/";
        public const string BaseUrl = DockerUrl;

        public ApiClient(AppSession session, HttpClient httpClient, IRefreshTokenService refreshTokenService)
        {
            _session = session;
            _httpClient = httpClient;
            _refreshTokenService = refreshTokenService;

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

        private async Task<HttpResponseMessage> SendWithRefreshAsync(Func<HttpRequestMessage> requestFactory)
        {
            // Proactive check: if access token has already expired and user is logged in
            if (_session.IsLoggedIn && _session.IsAccessTokenExpired)
            {
                await _refreshTokenService.RefreshTokenAsync();
            }

            var request = requestFactory();
            AttachToken(request);

            var response = await _httpClient.SendAsync(request);

            // Reactive check: on 401 Unauthorized for a logged in user, refresh and retry once
            // If the refresh token is also expired or missing, RefreshTokenAsync will trigger HandleSessionExpired()
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && _session.IsLoggedIn)
            {
                bool refreshed = await _refreshTokenService.RefreshTokenAsync();
                if (refreshed)
                {
                    var retryRequest = requestFactory();
                    AttachToken(retryRequest);
                    response = await _httpClient.SendAsync(retryRequest);
                }
            }

            return response;
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            var response = await SendWithRefreshAsync(() => new HttpRequestMessage(HttpMethod.Get, endpoint));
            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            var response = await SendWithRefreshAsync(() => new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = JsonContent.Create(data)
            });
            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            var response = await SendWithRefreshAsync(() => new HttpRequestMessage(HttpMethod.Put, endpoint)
            {
                Content = JsonContent.Create(data)
            });
            return await ProcessResponse<T>(response);
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
        {
            var response = await SendWithRefreshAsync(() => new HttpRequestMessage(HttpMethod.Delete, endpoint));
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
