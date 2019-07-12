using System;

namespace BaseModel
{
    public abstract class MNoDelete : MBase
    {
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
