namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public interface ITasksService
    {
        Task CreateAsync(string name, string userId);

        Task CompleteTask(int id);

        IEnumerable<TaskViewModel> GetAll(string userId, bool done);
    }
}
