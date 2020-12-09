using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyWeddingPlanner.Web.ViewModels.Blog;

namespace MyWeddingPlanner.Services.Data
{
    public class BlogPostsService:IBlogPostsService
    {
        public Task CreateAsync(CreateBlogPostInputModel input, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostViewModel> GetAll(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public BlogPostViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostViewModel> GetByCategory(int page, int itemsPerPage, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
