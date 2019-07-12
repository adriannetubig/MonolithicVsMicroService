using MonolithicMvc.Models;
using System.Threading.Tasks;

namespace MonolithicMvc.Helper
{
    public interface IDataService
    {
        Task Create(Login login, int createdBy);
        Task Read();
        Task Read(int loginId);
        Task Update(Login login, int updatedBy);
        Task Delete(Login login, int updatedBy);
    }
}
