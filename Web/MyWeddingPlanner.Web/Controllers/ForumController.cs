namespace MyWeddingPlanner.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Forum;

    public class ForumController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IPostCategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumController(
            IPostsService postsService,
            IPostCategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var item = this.postsService.GetById(id);
            if (item == null)
            {
                return this.NotFound();
            }

            return this.View(item);
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new PostsListViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Posts = this.postsService.GetAll(id, 12),
                ItemsCount = this.postsService.GetCount(),
            };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePostInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.postsService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/Forum/All");
        }
    }
}
