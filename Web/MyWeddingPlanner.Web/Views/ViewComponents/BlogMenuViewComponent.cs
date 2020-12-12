namespace MyWeddingPlanner.Web.Views.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data;
    using MyWeddingPlanner.Data.Models.Blog;

    public class BlogMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public BlogMenuViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await this.GetItemsAsync();
            return this.View(items);
        }

        private Task<List<BlogCategory>> GetItemsAsync()
        {
            return this.db.BlogCategories.OrderBy(s => s.Name).ToListAsync();
        }
    }
}
