using BaseModel;

namespace WarehouseModel
{
    public class InventoryItem : MBase
    {
        public int InventoryItemId { get; set; }
        public string InventoryName { get; set; }
    }
}
