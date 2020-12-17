namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.Forum;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;

    public interface IPostsService
    {
        Task CreateAsync(CreatePostInputModel input, string userId);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();

        T GetById<T>(int id);

        IEnumerable<T> GetByCategory<T>(int page, int itemsPerPage, int categoryId);
    }
}
