using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseModel;

namespace WarehouseBusiness.Interfaces
{
    public interface IBOrderItems
    {
        Task Create(OrderItem orderItem, int createdBy);
        Task<List<OrderItem>> Read();
        Task<OrderItem> Read(int orderItemId);
        Task Update(OrderItem orderItem, int updatedBy);
        Task Delete(int orderItemId, int deletedBy);
    }
}
