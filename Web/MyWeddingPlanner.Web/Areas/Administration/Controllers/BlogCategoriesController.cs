namespace MyWeddingPlanner.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyWeddingPlanner.Data;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Blog;

    [Area("Administration")]
    public class BlogCategoriesController : Controller
    {
        private readonly IDeletableEntityRepository<BlogCategory> dataRepository;

        public BlogCategoriesController(IDeletableEntityRepository<BlogCategory> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/BlogCategories
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.All().ToListAsync());
        }

        // GET: Administration/BlogCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogCategory == null)
            {
                return this.NotFound();
            }

            return this.View(blogCategory);
        }

        // GET: Administration/BlogCategories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/BlogCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BlogCategory blogCategory)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(blogCategory);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(blogCategory);
        }

        // GET: Administration/BlogCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (blogCategory == null)
            {
                return this.NotFound();
            }

            return this.View(blogCategory);
        }

        // POST: Administration/BlogCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BlogCategory blogCategory)
        {
            if (id != blogCategory.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(blogCategory);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BlogCategoryExists(blogCategory.Id))
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

            return this.View(blogCategory);
        }

        // GET: Administration/BlogCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogCategory == null)
            {
                return this.NotFound();
            }

            return this.View(blogCategory);
        }

        // POST: Administration/BlogCategories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(blogCategory);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BlogCategoryExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
