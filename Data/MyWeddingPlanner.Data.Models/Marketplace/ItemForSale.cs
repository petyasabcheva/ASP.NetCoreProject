using System.Collections.Generic;

using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models.Marketplace
{
    public class ItemForSale : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool Sold { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
