namespace MyWeddingPlanner.Web.ViewModels.Blog
{
    using Ganss.XSS;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Services.Mapping;

    public class ArticleViewModel : IMapFrom<BlogArticle>
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string Email { get; set; }

        public string ShortContent
        {
            get
            {
                var content = this.SanitizedContent;
                return content.Length > 300
                    ? content.Substring(0, 300) + "..."
                    : content;
            }
        }
    }
}
