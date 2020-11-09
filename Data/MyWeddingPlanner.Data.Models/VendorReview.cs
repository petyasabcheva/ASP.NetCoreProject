namespace MyWeddingPlanner.Data.Models
{

    public class VendorReview
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }

        public string VendorId { get; set; }

        public virtual ApplicationUser Vendor { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
