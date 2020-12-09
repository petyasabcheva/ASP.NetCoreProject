using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeddingPlanner.Common;
using MyWeddingPlanner.Data.Models;
using MyWeddingPlanner.Data.Models.Forum;
using MyWeddingPlanner.Data.Models.Marketplace;
using MyWeddingPlanner.Data.Models.Vendors;

namespace MyWeddingPlanner.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Services.Any())
            {


                var services = GlobalConstants.allServices.Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x)
                    .ToList();

                foreach (var service in services)
                {
                    await dbContext.Services.AddAsync(new Service() { Name = service });

                }
            }

            if (!dbContext.ItemsCategories.Any())
            {
                var itemCategories = GlobalConstants.allMarketplaceCategories
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

                foreach (var category in itemCategories)
                {
                    await dbContext.ItemsCategories.AddAsync(new ItemsCategory() { Name = category });
                }
            }

            if (!dbContext.ForumCategories.Any())
            {
                var itemCategories = GlobalConstants.allServices
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

                foreach (var category in itemCategories)
                {
                    await dbContext.ForumCategories.AddAsync(new ForumCategory() { Name = category });
                }
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
