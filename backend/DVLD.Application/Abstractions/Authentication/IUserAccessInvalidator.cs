namespace DVLD.Application.Abstractions.Authentication
{
    public interface IUserAccessInvalidator
    {
        void InvalidateUserAccess(int userId);
        bool IsTokenInvalidated(int userId, DateTime tokenIssuedAtUtc);
    }
}
