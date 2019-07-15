using CredentialModel;

namespace CredentialBusiness.Interfaces
{
    public interface IBAuthentications
    {
        Authentication Create(Login login);
    }
}
