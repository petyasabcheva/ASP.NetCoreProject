using System;
using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class Image:BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

    }
}
