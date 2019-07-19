using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseEntity;

namespace WarehouseData.Interfaces
{
    public interface IDOrderItems
    {
        Task Create(EOrderItem orderItem, int createdBy);
        Task<List<EOrderItem>> Read();
        Task<EOrderItem> Read(int orderItemId);
        Task Update(EOrderItem orderItem, int updatedBy);
        Task Delete(int orderItemId, int deletedBy);
    }
}
