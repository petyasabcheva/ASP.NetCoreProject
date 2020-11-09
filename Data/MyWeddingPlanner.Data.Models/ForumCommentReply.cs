using System.Collections.Generic;

namespace MyWeddingPlanner.Data.Models
{
    public class ForumCommentReply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string CommentId { get; set; }

        public virtual ForumComment Comment { get; set; }

    }
}
