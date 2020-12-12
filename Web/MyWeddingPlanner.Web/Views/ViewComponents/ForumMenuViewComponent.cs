namespace MyWeddingPlanner.Web.Views.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data;
    using MyWeddingPlanner.Data.Models.Forum;

    public class ForumMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public ForumMenuViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await this.GetItemsAsync();
            return this.View(items);
        }

        private Task<List<ForumCategory>> GetItemsAsync()
        {
            return this.db.ForumCategories.OrderBy(s => s.Name).ToListAsync();
        }
    }
}
