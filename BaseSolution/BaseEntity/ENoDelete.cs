using System;

namespace BaseEntity
{
    public abstract class ENoDelete :EBase
    {
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
