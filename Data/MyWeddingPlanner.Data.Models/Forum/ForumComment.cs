namespace MyWeddingPlanner.Data.Models.Forum
{
    using MyWeddingPlanner.Data.Common.Models;

    public class ForumComment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string PostId { get; set; }

        public virtual ForumPost Post { get; set; }
    }
}
