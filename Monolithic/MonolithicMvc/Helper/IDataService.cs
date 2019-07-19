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

        Task InventoryItemsCreate(InventoryItem inventoryItem, int createdBy);
        Task<List<InventoryItem>> InventoryItemsRead();
        Task<InventoryItem> InventoryItemsRead(int inventoryItemId);
        Task InventoryItemsUpdate(InventoryItem inventoryItem, int updatedBy);
        Task InventoryItemsDelete(int inventoryItemId, int deletedBy);

        Task OrderItemsCreate(OrderItem orderItem, int createdBy);
        Task<List<OrderItem>> OrderItemsRead();
        Task<OrderItem> OrderItemsRead(int orderItemId);
        Task OrderItemsUpdate(OrderItem orderItem, int updatedBy);
        Task OrderItemsDelete(int orderItemId, int deletedBy);
    }
}
