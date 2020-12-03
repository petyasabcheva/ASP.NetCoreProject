namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Marketplace;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;

    public class ItemsService : IItemsService
    {
        private readonly IRepository<ItemForSale> itemsRepository;

        public ItemsService(IRepository<ItemForSale> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task CreateAsync(CreateItemInputModel input, string userId)
        {
            var item = new ItemForSale()
            {
                Name = input.Name,
                Description = input.Description,
                UserId = userId,
                Category = input.Category,
            };
            await this.itemsRepository.AddAsync(item);
            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var items = this.itemsRepository.AllAsNoTracking()
                .To<T>().ToList();
            return items;
        }

        public int GetCount()
        {
            return this.itemsRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var item = this.itemsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return item;
        }
    }
}
