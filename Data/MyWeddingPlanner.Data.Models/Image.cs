﻿namespace MyWeddingPlanner.Data.Models
{
    using System;

    using MyWeddingPlanner.Data.Common.Models;
    using MyWeddingPlanner.Data.Models.Vendors;

    public class Image : BaseModel<string>
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
