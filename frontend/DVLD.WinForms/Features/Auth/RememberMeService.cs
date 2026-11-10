using DVLD.WinForms.Properties;
using DVLD.WinForms.Shared.Helpers;
using System;

namespace DVLD.WinForms.Features.Auth
{
    public class RememberMeService : IRememberMeService
    {
        public void SaveCredentials(string username, string password)
        {
            try
            {
                Settings.Default.Username = username ?? string.Empty;
                Settings.Default.EncryptedPassword = SecurityHelper.EncryptPassword(password ?? string.Empty);
                Settings.Default.RememberMe = true;
                Settings.Default.Save();
            }
            catch
            {
                // Suppress if settings save fails
            }
        }

        public (string Username, string Password)? GetStoredCredentials()
        {
            try
            {
                if (Settings.Default.RememberMe)
                {
                    string username = Settings.Default.Username;
                    string password = SecurityHelper.DecryptPassword(Settings.Default.EncryptedPassword);

                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        return (username, password);
                    }
                }
            }
            catch
            {
                // Suppress if reading settings fails
            }

            return null;
        }

        public bool TryGetCredentials(out string username, out string password)
        {
            var credentials = GetStoredCredentials();
            if (credentials.HasValue)
            {
                username = credentials.Value.Username;
                password = credentials.Value.Password;
                return true;
            }

            username = string.Empty;
            password = string.Empty;
            return false;
        }

        public void ClearCredentials()
        {
            try
            {
                Settings.Default.Username = string.Empty;
                Settings.Default.EncryptedPassword = string.Empty;
                Settings.Default.RememberMe = false;
                Settings.Default.Save();
            }
            catch
            {
                // Suppress if clearing settings fails
            }
        }
    }
}
