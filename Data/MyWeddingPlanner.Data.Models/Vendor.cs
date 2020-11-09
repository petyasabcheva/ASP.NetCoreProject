using System.Collections.Generic;

namespace MyWeddingPlanner.Data.Models
{
    public class Vendor
    {
        public Vendor()
        {
            this.Services=new HashSet<Service>();
            this.Reviews=new HashSet<VendorReview>();
            this.Photos=new List<string>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public List<string> Photos { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<VendorReview> Reviews { get; set; }


    }
}
