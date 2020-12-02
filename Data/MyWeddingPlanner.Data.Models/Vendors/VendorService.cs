using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Data.Models.Vendors
{
    public class VendorService
    {
        public Vendor Vendor { get; set; }

        public int VendorId { get; set; }

        public Service Service { get; set; }

        public int ServiceId { get; set; }
    }
}
