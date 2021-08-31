using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class CategoryProductMapping
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public long? ProductId { get; set; }

        public virtual CategoryMaster Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
