using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class ToDo : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
