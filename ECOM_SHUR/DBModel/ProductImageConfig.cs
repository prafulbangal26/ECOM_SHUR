using System;
using System.Collections.Generic;

#nullable disable

namespace ECOM_SHUR.DBModel
{
    public partial class ProductImageConfig
    {
        public long PimageId { get; set; }
        public long? PsmId { get; set; }
        public byte[] Imagedata { get; set; }
        public string Imagename { get; set; }

        public virtual ProductMapping Psm { get; set; }
    }
}
