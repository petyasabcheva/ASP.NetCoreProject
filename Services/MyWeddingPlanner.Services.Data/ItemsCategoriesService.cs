namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Marketplace;

    public class ItemsCategoriesService : IItemsCategoriesService
    {
        private readonly IDeletableEntityRepository<ItemsCategory> categoryRepository;

        public ItemsCategoriesService(IDeletableEntityRepository<ItemsCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoryRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
