namespace MyWeddingPlanner.Web.ViewModels.Blog
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
