using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class Photo : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
