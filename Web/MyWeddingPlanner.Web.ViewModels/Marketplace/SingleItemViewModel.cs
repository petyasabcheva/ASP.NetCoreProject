using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Web.ViewModels.Marketplace
{
    public class SingleItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] ImageUrls { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string SellerEmail { get; set; }

        public string SellerPhone { get; set; }
    }
}
