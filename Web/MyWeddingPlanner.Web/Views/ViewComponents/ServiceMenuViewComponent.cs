namespace MyWeddingPlanner.Data.Common.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data.Models.Vendors;

    public class ServiceMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public ServiceMenuViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await this.GetItemsAsync();
            return this.View(items);
        }

        private Task<List<Service>> GetItemsAsync()
        {
            return this.db.Services.OrderBy(s => s.Name).ToListAsync();
        }
    }
}
