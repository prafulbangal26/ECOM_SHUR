using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class ProductCouponMapping
    {
        public long PcId { get; set; }
        public long? ProductId { get; set; }
        public long? CouponId { get; set; }

        public virtual CouponMaster Coupon { get; set; }
        public virtual Product Product { get; set; }
    }
}
