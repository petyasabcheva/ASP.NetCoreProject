﻿using System.Collections.Generic;
using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class Vendor : BaseModel<int>
    {
        public Vendor()
        {
            this.Services=new HashSet<Service>();
            this.Reviews=new HashSet<VendorReview>();
            this.Images=new HashSet<Image>();
        }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public ICollection<Image> Images { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<VendorReview> Reviews { get; set; }


    }
}
