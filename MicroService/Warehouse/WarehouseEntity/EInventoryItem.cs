using BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace WarehouseEntity
{
    public class EInventoryItem : EBase
    {
        [Key]
        public int InventoryItemId { get; set; }
        public string InventoryName { get; set; }
    }
}
