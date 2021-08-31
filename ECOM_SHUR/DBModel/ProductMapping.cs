using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class ProductMapping
    {
        public ProductMapping()
        {
            ProductImageConfigs = new HashSet<ProductImageConfig>();
        }

        public long PsmId { get; set; }
        public long? ProductId { get; set; }
        public long? SizeId { get; set; }
        public long? ColorId { get; set; }
        public long? Quantity { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Discount { get; set; }

        public virtual ColorMaster Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual SizeMaster Size { get; set; }
        public virtual ICollection<ProductImageConfig> ProductImageConfigs { get; set; }
    }
}
