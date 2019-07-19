using BaseEntity;

namespace MonolithicMvc.Models
{
    public class InventoryItem : EBase
    {
        public int InventoryItemId { get; set; }
        public string InventoryName { get; set; }
    }
}