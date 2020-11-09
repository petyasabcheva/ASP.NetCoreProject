using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class Service : BaseDeletableModel<int>
    {
        public ServiceCategory Category { get; set; }

        public string Description { get; set; }

        public string PriceRangeMin { get; set; }

        public string PriceRangeMax { get; set; }

    }
}
