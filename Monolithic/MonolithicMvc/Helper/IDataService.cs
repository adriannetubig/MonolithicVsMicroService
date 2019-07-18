using MonolithicMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithicMvc.Helper
{
    public interface IDataService
    {
        Task LoginsCreate(Login login, int createdBy);
        Task<List<Login>> LoginsRead();
        Task<Login> LoginsRead(int loginId);
        Task<Login> LoginsRead(string username);
        Task LoginsUpdate(Login login, int updatedBy);
        Task LoginsDelete(int loginId, int deletedBy);
    }
}
