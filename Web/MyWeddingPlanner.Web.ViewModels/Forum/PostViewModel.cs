using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        //public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserName { get; set; }

        public int VotesCount { get; set; }

        //public IEnumerable<PostCommentViewModel> Comments { get; set; }
    }
}
