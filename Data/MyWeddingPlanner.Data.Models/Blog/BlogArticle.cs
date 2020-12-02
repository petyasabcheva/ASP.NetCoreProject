using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models.Blog
{
    public class BlogArticle : BaseDeletableModel<int>
    {
        public int CategoryId { get; set; }

        public virtual BlogCategory Category { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
