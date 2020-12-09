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

        IEnumerable<PostViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        PostViewModel GetById(int id);

        IEnumerable<PostViewModel> GetByCategory(int page, int itemsPerPage, int categoryId);
    }
}
