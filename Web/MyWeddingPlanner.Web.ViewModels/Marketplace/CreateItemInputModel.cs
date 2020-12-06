namespace MyWeddingPlanner.Web.ViewModels.Marketplace
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateItemInputModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
