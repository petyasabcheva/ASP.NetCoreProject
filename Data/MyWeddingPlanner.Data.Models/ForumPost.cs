using System.Collections.Generic;

namespace MyWeddingPlanner.Data.Models
{
    public class ForumPost
    {
        public ForumPost()
        {
            this.Comments=new HashSet<ForumComment>();
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<ForumComment> Comments { get; set; }
    }
}
