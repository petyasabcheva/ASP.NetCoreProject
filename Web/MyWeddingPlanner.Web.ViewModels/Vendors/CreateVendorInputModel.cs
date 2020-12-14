namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateVendorInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        [Display(Name = "Web page")]
        public string WebPage { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        [Display(Name = "Offered services")]
        public List<int> ReturnedServices { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Services { get; set; }
    }
}
