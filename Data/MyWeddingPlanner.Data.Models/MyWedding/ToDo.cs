namespace MyWeddingPlanner.Data.Models.MyWedding
{
    using MyWeddingPlanner.Data.Common.Models;

    public class ToDo : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
