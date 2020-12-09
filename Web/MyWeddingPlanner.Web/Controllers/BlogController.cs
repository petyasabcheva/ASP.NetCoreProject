namespace MyWeddingPlanner.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;
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
        private readonly IMapper mapper;

        public BlogController(
            IArticlesService articlesService,
            IBlogCategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        // public IActionResult ById(int id)
        // {
        //    var postViewModel = this.postsService.GetById<PostViewModel>(id);
        //    if (postViewModel == null)
        //    {
        //        return this.NotFound();
        //    }

        // return this.View(postViewModel);
        // }
        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new ArticleListViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Articles = this.articlesService.GetAll(id, 12),
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
            // if (!this.ModelState.IsValid)
            // {
            //    return this.View(input);
            // }
            var user = await this.userManager.GetUserAsync(this.User);

            // try
            // {
            await this.articlesService.CreateAsync(input, user.Id);

            // }
            // catch (Exception ex)
            // {
            //    this.ModelState.AddModelError(string.Empty, ex.Message);
            //    return this.View(input);
            // }

            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }
    }
}
