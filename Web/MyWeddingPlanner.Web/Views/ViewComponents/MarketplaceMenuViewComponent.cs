namespace MyWeddingPlanner.Web.Views.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data;
    using MyWeddingPlanner.Data.Models.Marketplace;

    public class MarketplaceMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public MarketplaceMenuViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await this.GetItemsAsync();
            return this.View(items);
        }

        private Task<List<ItemsCategory>> GetItemsAsync()
        {
            return this.db.ItemsCategories.OrderBy(s => s.Name).ToListAsync();
        }
    }
}
