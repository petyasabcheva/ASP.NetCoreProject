using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    public class VendorsListViewModel:PagingViewModel
    {
        public IEnumerable<VendorInListViewModel> Vendors { get; set; }

    }
}
