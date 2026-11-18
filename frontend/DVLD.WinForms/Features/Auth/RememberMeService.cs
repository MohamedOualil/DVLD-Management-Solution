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
                Properties.Settings.Default.Username = username ?? string.Empty;
                Properties.Settings.Default.EncryptedPassword = SecurityHelper.EncryptPassword(password ?? string.Empty);
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();
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
                if (Properties.Settings.Default.RememberMe)
                {
                    string username = Properties.Settings.Default.Username;
                    string password = SecurityHelper.DecryptPassword(Properties.Settings.Default.EncryptedPassword);

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
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.EncryptedPassword = string.Empty;
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
            catch
            {
                // Suppress if clearing settings fails
            }
        }
    }
}
