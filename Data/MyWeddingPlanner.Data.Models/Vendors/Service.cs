namespace MyWeddingPlanner.Data.Models.Vendors
{
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

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
