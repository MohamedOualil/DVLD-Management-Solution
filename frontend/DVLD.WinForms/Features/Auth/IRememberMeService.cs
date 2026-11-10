namespace DVLD.WinForms.Features.Auth
{
    public interface IRememberMeService
    {
        void SaveCredentials(string username, string password);
        (string Username, string Password)? GetStoredCredentials();
        bool TryGetCredentials(out string username, out string password);
        void ClearCredentials();
    }
}
