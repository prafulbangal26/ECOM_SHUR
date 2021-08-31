using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class ProductTagMapping
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? TagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual TagMaster Tag { get; set; }
    }
}
