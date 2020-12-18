namespace MyWeddingPlanner.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Blog;

    [Area("Administration")]
    public class BlogArticlesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<BlogArticle> dataRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IArticlesService articlesService;
        private readonly IBlogCategoriesService categoriesService;
        private readonly IDeletableEntityRepository<BlogCategory> categoriesRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogArticlesController(
            IDeletableEntityRepository<BlogArticle> dataRepository,
            IArticlesService articlesService,
            IBlogCategoriesService categoriesService,
            IDeletableEntityRepository<BlogCategory> categoriesRepository,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository)
        {
            this.dataRepository = dataRepository;
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.categoriesRepository = categoriesRepository;
        }

        // GET: Administration/BlogArticles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.dataRepository.All().Include(b => b.Author).Include(b => b.Category);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/BlogArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogArticle = await this.dataRepository.All()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogArticle == null)
            {
                return this.NotFound();
            }

            return this.View(blogArticle);
        }

        // GET: Administration/BlogArticles/Create
        // public IActionResult Create()
        // {
        //    this.ViewData["AuthorId"] = new SelectList(this.dataRepository.Users, "Id", "Id");
        //    this.ViewData["CategoryId"] = new SelectList(this.dataRepository.BlogCategories, "Id", "Id");
        //    return this.View();
        // }

        //// POST: Administration/BlogArticles/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("CategoryId,Title,Content,AuthorId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BlogArticle blogArticle)
        // {
        //    if (this.ModelState.IsValid)
        //    {
        //        this.dataRepository.Add(blogArticle);
        //        await this.dataRepository.SaveChangesAsync();
        //        return this.RedirectToAction(nameof(this.Index));
        //    }

        // this.ViewData["AuthorId"] = new SelectList(this.dataRepository.Users, "Id", "Id", blogArticle.AuthorId);
        //    this.ViewData["CategoryId"] = new SelectList(this.dataRepository.BlogCategories, "Id", "Id", blogArticle.CategoryId);
        //    return this.View(blogArticle);
        // }
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

        // GET: Administration/BlogArticles/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogArticle = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (blogArticle == null)
            {
                return this.NotFound();
            }

            this.ViewData["AuthorId"] = new SelectList(this.userRepository.All(), "Id", "Id", blogArticle.AuthorId);
            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id", blogArticle.CategoryId);
            return this.View(blogArticle);
        }

        // POST: Administration/BlogArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Title,Content,AuthorId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BlogArticle blogArticle)
        {
            if (id != blogArticle.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(blogArticle);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BlogArticleExists(blogArticle.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["AuthorId"] = new SelectList(this.userRepository.All(), "Id", "Id", blogArticle.AuthorId);
            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id", blogArticle.CategoryId);
            return this.View(blogArticle);
        }

        // GET: Administration/BlogArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogArticle = await this.dataRepository.All()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogArticle == null)
            {
                return this.NotFound();
            }

            return this.View(blogArticle);
        }

        // POST: Administration/BlogArticles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogArticle = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(blogArticle);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BlogArticleExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
