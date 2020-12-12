namespace MyWeddingPlanner.Web.ViewModels.Marketplace
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateItemInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public string Category { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
