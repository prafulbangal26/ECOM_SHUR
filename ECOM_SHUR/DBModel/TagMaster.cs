using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class TagMaster
    {
        public TagMaster()
        {
            ProductTagMappings = new HashSet<ProductTagMapping>();
        }

        public long TagId { get; set; }
        public string TagName { get; set; }
        public string TagMetaname { get; set; }
        public string TagSlug { get; set; }
        public string TagDescription { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }

        public virtual ICollection<ProductTagMapping> ProductTagMappings { get; set; }
    }
}
