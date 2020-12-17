namespace MyWeddingPlanner.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Blog;

    public class BlogController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly IBlogCategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogController(
            IArticlesService articlesService,
            IBlogCategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var item = this.articlesService.GetById<ArticleViewModel>(id);

            if (item == null)
            {
                return this.NotFound();
            }

            return this.View(item);
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new ArticleListViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Articles = this.articlesService.GetAll<ArticleViewModel>(id, 12),
                ItemsCount = this.articlesService.GetCount(),
            };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.articlesService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/Blog/All");
        }

        public IActionResult Category(int categoryId, string categoryName, int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new ArticleListViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Articles = this.articlesService.GetByCategory<ArticleViewModel>(1, 12, categoryId),
                ItemsCount = this.articlesService.GetCount(),
                CategoryName = categoryName,
            };
            return this.View(viewModel);
        }
    }
}
