using System.Collections.Generic;

using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class BlogCategory : BaseModel<int>
    {
        public BlogCategory()
        {
            this.Articles = new HashSet<BlogArticle>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BlogArticle> Articles { get; set; }
    }
}
