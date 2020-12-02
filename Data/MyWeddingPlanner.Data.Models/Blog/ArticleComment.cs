using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models.Blog
{
    public class ArticleComment : BaseDeletableModel<int>
    {
        public int ArticleId { get; set; }

        public virtual BlogArticle Article { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
