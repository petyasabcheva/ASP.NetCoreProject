using System.Collections.Generic;
using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models.Vendors
{
    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.VendorServices = new HashSet<VendorService>();

        }

        public string Name { get; set; }

        public virtual ICollection<VendorService> VendorServices { get; set; }
    }
}
