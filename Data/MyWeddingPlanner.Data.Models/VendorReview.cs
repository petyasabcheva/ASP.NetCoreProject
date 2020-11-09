using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{

    public class VendorReview : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }

        public string VendorId { get; set; }

        public virtual ApplicationUser Vendor { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
