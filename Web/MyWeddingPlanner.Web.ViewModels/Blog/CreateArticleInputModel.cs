namespace MyWeddingPlanner.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    public class CreateArticleInputModel
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
