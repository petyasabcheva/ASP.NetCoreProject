using MyWeddingPlanner.Data.Models;

namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;

    public class SingleVendorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] ServicesNames { get; set; }

        public string User { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public string[] ImageUrls { get; set; }
    }
}
