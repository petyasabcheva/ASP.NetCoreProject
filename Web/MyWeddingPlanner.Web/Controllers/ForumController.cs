using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWeddingPlanner.Data.Models;
using MyWeddingPlanner.Services.Data;
using MyWeddingPlanner.Web.ViewModels.Forum;
using MyWeddingPlanner.Web.ViewModels.Marketplace;

namespace MyWeddingPlanner.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IPostCategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public ForumController(
            IPostsService postsService,
            IPostCategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        //public IActionResult ById(int id)
        //{
        //    var postViewModel = this.postsService.GetById<PostViewModel>(id);
        //    if (postViewModel == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(postViewModel);
        //}

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
            // if (!this.ModelState.IsValid)
            // {
            //    return this.View(input);
            // }
            var user = await this.userManager.GetUserAsync(this.User);

            // try
            // {
            await this.postsService.CreateAsync(input, user.Id);

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
