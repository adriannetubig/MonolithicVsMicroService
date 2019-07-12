using CredentialModel;

namespace CredentialBusiness.Interfaces
{
    public interface IBAuthentication
    {
        Authentication Create(string refreshToken, Login login);
    }
}
