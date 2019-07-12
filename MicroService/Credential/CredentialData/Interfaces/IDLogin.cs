using CredentialEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CredentialData.Interfaces
{
    public interface IDLogin
    {
        Task Create(ELogin login, int createdBy);
        Task<List<ELogin>> Read();
        Task<ELogin> Read(int loginId);
        Task<ELogin> Read(string username);
        Task Update(ELogin login, int updatedBy);
        Task Delete(int loginId, int deletedBy);
    }
}
