using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class Product
    {
        public Product()
        {
            CategoryProductMappings = new HashSet<CategoryProductMapping>();
            ProductCouponMappings = new HashSet<ProductCouponMapping>();
            ProductMappings = new HashSet<ProductMapping>();
            ProductTagMappings = new HashSet<ProductTagMapping>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductMetaname { get; set; }
        public string ProductSlug { get; set; }
        public string ProductDescription { get; set; }
        public string ProductSummery { get; set; }
        public string ProductSku { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductDiscount { get; set; }
        public bool? IsForShop { get; set; }
        public long? ProductQuanitity { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool? IsForSale { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public virtual ICollection<CategoryProductMapping> CategoryProductMappings { get; set; }
        public virtual ICollection<ProductCouponMapping> ProductCouponMappings { get; set; }
        public virtual ICollection<ProductMapping> ProductMappings { get; set; }
        public virtual ICollection<ProductTagMapping> ProductTagMappings { get; set; }
    }
}
