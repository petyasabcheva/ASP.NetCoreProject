namespace MyWeddingPlanner.Data.Models
{
    public class Service
    {
        public int Id { get; set; }

        public ServiceCategory Category { get; set; }

        public string Description { get; set; }

        public string PriceRangeMin { get; set; }

        public string PriceRangeMax { get; set; }

    }
}
