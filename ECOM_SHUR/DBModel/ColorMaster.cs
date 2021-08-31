using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class ColorMaster
    {
        public ColorMaster()
        {
            ProductMappings = new HashSet<ProductMapping>();
        }

        public long ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorHexcode { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }

        public virtual ICollection<ProductMapping> ProductMappings { get; set; }
    }
}
