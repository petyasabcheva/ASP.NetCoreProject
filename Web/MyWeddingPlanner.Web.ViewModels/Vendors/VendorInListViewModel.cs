using MyWeddingPlanner.Data.Models.Vendors;
using MyWeddingPlanner.Services.Mapping;

namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;

    public class VendorInListViewModel : IMapFrom<Vendor>
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }


    }
}
