using DVLD.Contracts.Auth;
using DVLD.WinForms.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly AppSession _session;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public event EventHandler? OnSessionExpired;

        public RefreshTokenService(AppSession session, HttpClient httpClient)
        {
            _session = session;
            _httpClient = httpClient;

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(ApiClient.BaseUrl);
            }
        }

        public async Task<bool> RefreshTokenAsync()
        {
            if (!_session.CanRefresh)
            {
                HandleSessionExpired();
                return false;
            }

            await _semaphore.WaitAsync();
            try
            {
                // Double-check: If another concurrent call already refreshed while waiting on the lock
                if (!_session.IsAccessTokenExpired && !string.IsNullOrEmpty(_session.CurrentToken))
                {
                    return true;
                }

                var request = new RefreshTokenRequest(_session.RefreshToken);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "auth/refresh")
                {
                    Content = JsonContent.Create(request)
                };

                var response = await _httpClient.SendAsync(requestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    HandleSessionExpired();
                    return false;
                }

                var json = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);

                if (tokenResponse == null || string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
                {
                    HandleSessionExpired();
                    return false;
                }

                _session.UpdateTokens(tokenResponse);
                return true;
            }
            catch
            {
                HandleSessionExpired();
                return false;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private void HandleSessionExpired()
        {
            _session.Logout();
            OnSessionExpired?.Invoke(this, EventArgs.Empty);
        }
    }
}
