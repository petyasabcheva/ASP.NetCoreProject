namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.Blog;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel input, string userId);

        IEnumerable<ArticleViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        ArticleViewModel GetById(int id);

        IEnumerable<ArticleViewModel> GetByCategory(int page, int itemsPerPage, int categoryId);
    }
}
