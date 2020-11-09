using System.Collections.Generic;

using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class ForumCategory : BaseModel<int>
    {
        public ForumCategory()
        {
            this.Posts = new HashSet<ForumPost>();
        }

        public string Name { get; set; }

        public virtual ICollection<ForumPost> Posts { get; set; }

    }
}
