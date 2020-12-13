namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    using System;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using MyWeddingPlanner.Data.Models.Forum;
    using MyWeddingPlanner.Services.Mapping;

    public class PostViewModel : IMapFrom<ForumPost>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string Email { get; set; }

        public int VotesCount { get; set; }

        // public IEnumerable<PostCommentViewModel> Comments { get; set; }
        public string ShortContent
        {
            get
            {
                var content = Regex.Replace(this.SanitizedContent, "\\<[^\\>]*\\>", string.Empty);
                return content.Length > 300
                    ? content.Substring(0, 300) + "..."
                    : content;
            }
        }
    }
}
