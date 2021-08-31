using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class SizeMaster
    {
        public SizeMaster()
        {
            ProductMappings = new HashSet<ProductMapping>();
        }

        public long SizeId { get; set; }
        public string SizeType { get; set; }
        public string SizeRange { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }

        public virtual ICollection<ProductMapping> ProductMappings { get; set; }
    }
}
