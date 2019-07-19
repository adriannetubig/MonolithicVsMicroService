using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseEntity;

namespace WarehouseData.Interfaces
{
    public interface IDInventoryItems
    {
        Task Create(EInventoryItem inventoryItem, int createdBy);
        Task<List<EInventoryItem>> Read();
        Task<EInventoryItem> Read(int inventoryItemId);
        Task Update(EInventoryItem inventoryItem, int updatedBy);
        Task Delete(int inventoryItemId, int deletedBy);
    }
}
