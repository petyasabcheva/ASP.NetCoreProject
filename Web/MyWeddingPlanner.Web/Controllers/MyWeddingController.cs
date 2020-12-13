namespace MyWeddingPlanner.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public class MyWeddingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWeddingService weddingService;
        private readonly IGuestsService guestsService;
        private readonly IExpensesService expensesService;
        private readonly ITasksService tasksService;

        public MyWeddingController(UserManager<ApplicationUser> userManager, IWeddingService weddingService, IGuestsService guestsService, IExpensesService expensesService, ITasksService tasksService)
        {
            this.userManager = userManager;
            this.weddingService = weddingService;
            this.guestsService = guestsService;
            this.tasksService = tasksService;
            this.expensesService = expensesService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var wedding = this.weddingService.GetWedding(user.Id);
            if (wedding == null)
            {
                return this.Redirect("/MyWedding/Create");
            }
            else
            {
                return this.View(wedding);
            }
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateWeddingInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.weddingService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/MyWedding/Index");
        }

        public async Task<IActionResult> AllGuests()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new GuestListViewModel()
            {
                BrideGuests = this.guestsService.GetAll(user.Id, 1),
                GroomGuests = this.guestsService.GetAll(user.Id, 2),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AllGuests(int id, string fullName, int table)
        {
            var input = new CreateGuestInputModel
            {
                FullName = fullName,
                Table = table,
                Side = id,
            };

            // if (!this.ModelState.IsValid)
            // {
            //    return this.View(input);
            // }
            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.guestsService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.Redirect("/MyWedding/AllGuests");
        }

        public async Task<IActionResult> AllTasks()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new TaskListViewModel
            {
                CompletedTasks = this.tasksService.GetAll(user.Id, true),
                NonCompletedTasks = this.tasksService.GetAll(user.Id, false),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AllTasks(string name)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.tasksService.CreateAsync(name, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.Redirect("/MyWedding/AllTasks");
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(int id)
        {
            await this.tasksService.CompleteTask(id);
            return this.Redirect("/MyWedding/AllTasks");
        }

        public async Task<IActionResult> Budget()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new BudgetViewModel()
            {
                Expenditures = this.expensesService.GetAll(user.Id),
                Budget = this.weddingService.GetWedding(user.Id).Budget,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Budget(string name, decimal totalAmount, decimal paidAmount, DateTime dueDate)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.expensesService.CreateAsync(name, totalAmount, paidAmount, dueDate, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.Redirect("/MyWedding/Budget");
        }
    }
}
