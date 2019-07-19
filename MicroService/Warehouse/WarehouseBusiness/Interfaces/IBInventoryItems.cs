using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseModel;

namespace WarehouseBusiness.Interfaces
{
    public interface IBInventoryItems
    {
        Task Create(InventoryItem inventoryItem, int createdBy);
        Task<List<InventoryItem>> Read();
        Task<InventoryItem> Read(int inventoryItemId);
        Task Update(InventoryItem inventoryItem, int updatedBy);
        Task Delete(int inventoryItemId, int deletedBy);
    }
}
