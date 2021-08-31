using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class CategoryMaster
    {
        public CategoryMaster()
        {
            CategoryProductMappings = new HashSet<CategoryProductMapping>();
        }

        public long CategoryId { get; set; }
        public long? CategoryParentid { get; set; }
        public string CategoryName { get; set; }
        public string CategoryMetaname { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryDescription { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }

        public virtual ICollection<CategoryProductMapping> CategoryProductMappings { get; set; }
    }
}
