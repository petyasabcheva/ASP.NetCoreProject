namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System.Collections.Generic;

    public class TaskListViewModel
    {
        public IEnumerable<TaskViewModel> CompletedTasks { get; set; }

        public IEnumerable<TaskViewModel> NonCompletedTasks { get; set; }
    }
}
