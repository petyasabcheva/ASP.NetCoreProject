namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateVendorInputModel
    {
        // public CreateVendorInputModel()
        // {
        //    this.Services=new HashSet<KeyValuePair<string,string>>();
        // }
        public string Name { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebPage { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public List<int> ReturnedServices { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Services { get; set; }
    }
}
