using BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace WarehouseEntity
{
    public class EOrderItem : EBase
    {
        [Key]
        public int OrderItemId { get; set; }
        public string OrderName { get; set; }
    }
}
