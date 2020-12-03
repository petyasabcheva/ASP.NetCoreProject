namespace MyWeddingPlanner.Data.Models.Forum
{
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

    public class ForumPost : BaseDeletableModel<int>
    {
        public ForumPost()
        {
            this.Comments = new HashSet<ForumComment>();
        }

        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<ForumComment> Comments { get; set; }
    }
}
