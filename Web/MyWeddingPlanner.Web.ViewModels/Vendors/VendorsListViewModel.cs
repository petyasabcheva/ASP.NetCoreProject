namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;

    public class VendorsListViewModel : PagingViewModel
    {
        public IEnumerable<VendorInListViewModel> Vendors { get; set; }

        public string CategoryName { get; set; }
    }
}
