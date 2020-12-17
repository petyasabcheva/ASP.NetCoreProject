namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ganss.XSS;
    using MyWeddingPlanner.Data.Models.Forum;
    using MyWeddingPlanner.Services.Mapping;

    public class CommentViewModel : IMapFrom<ForumComment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string AuthorEmail { get; set; }
    }
}
