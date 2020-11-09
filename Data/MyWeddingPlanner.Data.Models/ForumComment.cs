using System.Collections.Generic;
using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class ForumComment : BaseDeletableModel<int>
    {
        public ForumComment()
        {
            this.Replies=new HashSet<ForumCommentReply>();
        }
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string PostId { get; set; }

        public virtual ForumPost Post { get; set; }

        public virtual ICollection<ForumCommentReply> Replies { get; set; }
    }
}
