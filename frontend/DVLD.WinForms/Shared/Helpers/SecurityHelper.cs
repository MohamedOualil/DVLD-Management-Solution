using System;
using System.Security.Cryptography;
using System.Text;

namespace DVLD.WinForms.Shared.Helpers
{
    public static class SecurityHelper
    {
        // Extra layer of randomness (salt)
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("DVLDUniqueSecretSalt2026!");

        public static string EncryptPassword(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProtectedData.Protect(
                plainBytes,
                Entropy,
                DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptPassword(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return string.Empty;
            }

            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] plainBytes = ProtectedData.Unprotect(
                    encryptedBytes,
                    Entropy,
                    DataProtectionScope.CurrentUser);

                return Encoding.UTF8.GetString(plainBytes);
            }
            catch (CryptographicException)
            {
                // Returns empty if decrypted on a different machine/Windows account
                return string.Empty;
            }
            catch (FormatException)
            {
                return string.Empty;
            }
        }
    }
}
