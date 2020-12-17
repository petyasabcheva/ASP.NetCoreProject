

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
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumController(
            IPostsService postsService,
            IPostCategoriesService categoriesService,
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var item = this.postsService.GetById<PostViewModel>(id);
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
                Posts = this.postsService.GetAll<PostViewModel>(id, 12),
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

        public IActionResult Category(int id, string categoryName)
        {
            const int itemsPerPage = 12;
            var viewModel = new PostsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Posts = this.postsService.GetByCategory<PostViewModel>(1, 12, id),
                ItemsCount = this.postsService.GetCount(),
                CategoryName=categoryName,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CreateCommentInputModel input)
        {
            var parentId =
                input.ParentId == 0 ?
                    (int?)null :
                    input.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsInPostId(parentId.Value, input.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(input.PostId, userId, input.Content, parentId);
            return this.RedirectToAction("ById", "Forum", new { id = input.PostId });
        }
    }
}
