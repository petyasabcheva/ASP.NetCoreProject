namespace MyWeddingPlanner.Data.Models.MyWedding
{
    using MyWeddingPlanner.Data.Common.Models;

    public class Guest : BaseModel<int>
    {
        public string FullName { get; set; }

        public GuestSide Side { get; set; }

        public int Table { get; set; }
    }
}
