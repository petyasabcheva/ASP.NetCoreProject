namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Data.Models.Forum;

    public class BlogCategoriesService : IBlogCategoriesService
    {
        private readonly IDeletableEntityRepository<BlogCategory> categoryRepository;

        public BlogCategoriesService(IDeletableEntityRepository<BlogCategory> categoryRepository)
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
