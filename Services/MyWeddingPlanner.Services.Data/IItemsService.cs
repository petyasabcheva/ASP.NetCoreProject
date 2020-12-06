namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.Marketplace;

    public interface IItemsService
    {
        Task CreateAsync(CreateItemInputModel input, string userId, string imagePath);

        IEnumerable<ItemsInListViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        T GetById<T>(int id);
    }
}
