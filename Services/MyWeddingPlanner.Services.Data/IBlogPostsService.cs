using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyWeddingPlanner.Web.ViewModels.Blog;

namespace MyWeddingPlanner.Services.Data
{
    public interface IBlogPostsService
    {
        Task CreateAsync(CreateBlogPostInputModel input, string userId);

        IEnumerable<BlogPostViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        BlogPostViewModel GetById(int id);

        IEnumerable<BlogPostViewModel> GetByCategory(int page, int itemsPerPage, int categoryId);
    }
}
