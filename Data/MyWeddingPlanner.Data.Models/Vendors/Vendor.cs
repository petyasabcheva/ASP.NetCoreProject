﻿namespace MyWeddingPlanner.Data.Models.Vendors
{
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

    public class Vendor : BaseDeletableModel<int>
    {
        public Vendor()
        {
            this.Reviews = new HashSet<VendorReview>();
            this.VendorServices = new HashSet<VendorService>();
            this.Images = new HashSet<Image>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public ICollection<Image> Images { get; set; }

        public virtual ICollection<VendorService> VendorServices { get; set; }

        public virtual ICollection<VendorReview> Reviews { get; set; }
    }
}
