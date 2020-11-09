using System;
using System.Threading.Tasks;

namespace MyWeddingPlanner.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
