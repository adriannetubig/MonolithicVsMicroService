using CredentialModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CredentialBusiness.Interfaces
{
    public interface IBLogins
    {
        Task Create(Login login, int createdBy);
        Task<List<Login>> Read();
        Task<Login> Read(int loginId);
        Task<Login> Authenticate(Login login);
        Task Update(Login login, int updatedBy);
        Task Delete(int loginId, int deletedBy);
    }
}
