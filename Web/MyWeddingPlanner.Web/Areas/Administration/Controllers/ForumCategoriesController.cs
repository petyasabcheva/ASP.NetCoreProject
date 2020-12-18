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
    using MyWeddingPlanner.Data.Models.Forum;

    [Area("Administration")]
    public class ForumCategoriesController : Controller
    {
        private readonly IDeletableEntityRepository<ForumCategory> dataRepository;

        public ForumCategoriesController(IDeletableEntityRepository<ForumCategory> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/ForumCategories
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.All().ToListAsync());
        }

        // GET: Administration/ForumCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var forumCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumCategory == null)
            {
                return this.NotFound();
            }

            return this.View(forumCategory);
        }

        // GET: Administration/ForumCategories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/ForumCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ForumCategory forumCategory)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(forumCategory);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(forumCategory);
        }

        // GET: Administration/ForumCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var forumCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (forumCategory == null)
            {
                return this.NotFound();
            }

            return this.View(forumCategory);
        }

        // POST: Administration/ForumCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ForumCategory forumCategory)
        {
            if (id != forumCategory.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(forumCategory);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ForumCategoryExists(forumCategory.Id))
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

            return this.View(forumCategory);
        }

        // GET: Administration/ForumCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var forumCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumCategory == null)
            {
                return this.NotFound();
            }

            return this.View(forumCategory);
        }

        // POST: Administration/ForumCategories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(forumCategory);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ForumCategoryExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
