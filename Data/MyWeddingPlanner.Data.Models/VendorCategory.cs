using System.Collections.Generic;

namespace MyWeddingPlanner.Data.Models
{
    public class VendorCategory
    {
        public VendorCategory()
        {
            this.Vendors=new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Vendors { get; set; }

    }
}
