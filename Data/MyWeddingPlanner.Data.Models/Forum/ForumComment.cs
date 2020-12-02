using System.Collections.Generic;

using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models.Forum
{
    public class ForumComment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string PostId { get; set; }

        public virtual ForumPost Post { get; set; }

    }
}
