namespace MyWeddingPlanner.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Common;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Data.Models.Forum;
    using MyWeddingPlanner.Data.Models.Marketplace;
    using MyWeddingPlanner.Data.Models.Vendors;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Services.Any())
            {
                var services = GlobalConstants.AllServices.Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x)
                    .ToList();

                foreach (var service in services)
                {
                    await dbContext.Services.AddAsync(new Service() { Name = service });
                }
            }

            if (!dbContext.ItemsCategories.Any())
            {
                var itemCategories = GlobalConstants.AllMarketplaceCategories
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

                foreach (var category in itemCategories)
                {
                    await dbContext.ItemsCategories.AddAsync(new ItemsCategory() { Name = category });
                }
            }

            if (!dbContext.ForumCategories.Any())
            {
                var itemCategories = GlobalConstants.AllServices
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

                foreach (var category in itemCategories)
                {
                    await dbContext.ForumCategories.AddAsync(new ForumCategory() { Name = category });
                }
            }

            if (!dbContext.BlogCategories.Any())
            {
                var itemCategories = GlobalConstants.AllServices
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

                foreach (var category in itemCategories)
                {
                    await dbContext.BlogCategories.AddAsync(new BlogCategory() { Name = category });
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
