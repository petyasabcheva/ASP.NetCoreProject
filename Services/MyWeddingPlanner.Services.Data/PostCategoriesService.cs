using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWeddingPlanner.Data.Common.Repositories;
using MyWeddingPlanner.Data.Models.Forum;
using MyWeddingPlanner.Data.Models.Marketplace;

namespace MyWeddingPlanner.Services.Data
{
    public class PostCategoriesService:IPostCategoriesService
    {
        private readonly IDeletableEntityRepository<ForumCategory> categoryRepository;

        public PostCategoriesService(IDeletableEntityRepository<ForumCategory> categoryRepository)
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
