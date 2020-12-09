namespace MyWeddingPlanner.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;

    public class MarketplaceController : Controller
    {
        private readonly IItemsService itemsService;
        private readonly IItemsCategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public MarketplaceController(
            IItemsService itemsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment,
            IItemsCategoriesService categoriesService)
        {
            this.itemsService = itemsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateItemInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateItemInputModel input)
        {
            // if (!this.ModelState.IsValid)
            // {
            //    return this.View(input);
            // }
            var user = await this.userManager.GetUserAsync(this.User);

            // try
            // {
            await this.itemsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");

            // }
            // catch (Exception ex)
            // {
            //    this.ModelState.AddModelError(string.Empty, ex.Message);
            //    return this.View(input);
            // }

            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new ItemsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Items = this.itemsService.GetAll(id, 12),
                ItemsCount = this.itemsService.GetCount(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Category(int categoryId, string categoryName)
        {
            const int itemsPerPage = 12;
            var viewModel = new ItemsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = 1,
                Items = this.itemsService.GetByCategory(1, 12, categoryId),
                ItemsCount = this.itemsService.GetCount(),
                CategoryName = categoryName,
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var item = this.itemsService.GetById(id);
            return this.View(item);
        }
    }
}
