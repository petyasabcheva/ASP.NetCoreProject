namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public class TasksService : ITasksService
    {
        private readonly IRepository<Wedding> weddingRepository;
        private readonly IRepository<ToDo> taskRepository;

        public TasksService(IRepository<Wedding> weddingRepository, IRepository<ToDo> taskRepository)
        {
            this.weddingRepository = weddingRepository;
            this.taskRepository = taskRepository;
        }

        public async Task CreateAsync(string description, string userId)
        {
            var task = new ToDo()
            {
                Description = description,
                Completed = false,
            };

            var wedding = this.weddingRepository.All().FirstOrDefault(x => x.OwnerId == userId);
            wedding.ToDos.Add(task);
            await this.weddingRepository.SaveChangesAsync();
        }

        public async Task CompleteTask(int id)
        {
            var task = this.taskRepository.All().FirstOrDefault(x => x.Id == id);
            task.Completed = true;
            await this.taskRepository.SaveChangesAsync();
        }

        public IEnumerable<TaskViewModel> GetAll(string userId, bool completed)
        {
            var wedding = this.weddingRepository.All().FirstOrDefault(x => x.OwnerId == userId);
            var tasks = this.taskRepository.AllAsNoTracking()
                .Where(x => x.Completed == completed && wedding.OwnerId == userId)
                .Select(x => new TaskViewModel()
                {
                    Name = x.Description,
                    Done = x.Completed,
                    Id = x.Id,
                }).ToList();
            return tasks;
        }
    }
}
