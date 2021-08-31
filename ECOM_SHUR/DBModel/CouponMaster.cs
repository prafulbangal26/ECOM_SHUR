using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class CouponMaster
    {
        public CouponMaster()
        {
            ProductCouponMappings = new HashSet<ProductCouponMapping>();
        }

        public long Id { get; set; }
        public string CouponName { get; set; }
        public string CouponCode { get; set; }
        public decimal? CouponDiscount { get; set; }

        public virtual ICollection<ProductCouponMapping> ProductCouponMappings { get; set; }
    }
}
