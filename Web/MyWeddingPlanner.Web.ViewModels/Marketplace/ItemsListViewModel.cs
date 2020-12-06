namespace MyWeddingPlanner.Web.ViewModels.Marketplace
{
    using System.Collections.Generic;

    public class ItemsListViewModel : PagingViewModel
    {
        public IEnumerable<ItemsInListViewModel> Items { get; set; }

        public string CategoryName { get; set; }
    }
}
