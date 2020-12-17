namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePostInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
