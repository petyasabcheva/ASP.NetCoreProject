namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Web.ViewModels.Blog;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<BlogArticle> articleRepository;
        private readonly IDeletableEntityRepository<BlogCategory> categoryRepository;

        public ArticlesService(IDeletableEntityRepository<BlogArticle> articleRepository, IDeletableEntityRepository<BlogCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.articleRepository = articleRepository;
        }

        public async Task CreateAsync(CreateArticleInputModel input, string userId)
        {
            var item = new BlogArticle()
            {
                AuthorId = userId,
                CategoryId = input.CategoryId,
                Title = input.Title,
                Content = input.Content,
            };

            var category = this.categoryRepository.All().FirstOrDefault(x => x.Id == input.CategoryId);
            item.Category = category;

            await this.articleRepository.AddAsync(item);
            await this.articleRepository.SaveChangesAsync();
        }

        public IEnumerable<ArticleViewModel> GetAll(int page, int itemsPerPage)
        {
            var items = this.articleRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Email = x.Author.Email,
                }).ToList();
            return items;
        }

        public int GetCount()
        {
            return this.articleRepository.All().Count();
        }

        public ArticleViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> GetByCategory(int page, int itemsPerPage, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
