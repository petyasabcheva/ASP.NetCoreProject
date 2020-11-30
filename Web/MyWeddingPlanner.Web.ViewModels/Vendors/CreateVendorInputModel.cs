using System.Collections.Generic;
using MyWeddingPlanner.Data.Models;

namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    public class CreateVendorInputModel
    {
        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
