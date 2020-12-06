namespace MyWeddingPlanner.Data.Models.Marketplace
{
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

    public class ItemForSale : BaseDeletableModel<int>
    {
        public ItemForSale()
        {
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public ItemsCategory Category { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public decimal Price { get; set; }

        public bool Sold { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
