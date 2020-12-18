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
    using MyWeddingPlanner.Data.Models.Marketplace;

    [Area("Administration")]
    public class ItemsCategoriesController : Controller
    {
        private readonly IDeletableEntityRepository<ItemsCategory> dataRepository;

        public ItemsCategoriesController(IDeletableEntityRepository<ItemsCategory> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/ItemsCategories
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.All().ToListAsync());
        }

        // GET: Administration/ItemsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var itemsCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsCategory == null)
            {
                return this.NotFound();
            }

            return this.View(itemsCategory);
        }

        // GET: Administration/ItemsCategories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/ItemsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ItemsCategory itemsCategory)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(itemsCategory);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(itemsCategory);
        }

        // GET: Administration/ItemsCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var itemsCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (itemsCategory == null)
            {
                return this.NotFound();
            }

            return this.View(itemsCategory);
        }

        // POST: Administration/ItemsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ItemsCategory itemsCategory)
        {
            if (id != itemsCategory.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(itemsCategory);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ItemsCategoryExists(itemsCategory.Id))
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

            return this.View(itemsCategory);
        }

        // GET: Administration/ItemsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var itemsCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsCategory == null)
            {
                return this.NotFound();
            }

            return this.View(itemsCategory);
        }

        // POST: Administration/ItemsCategories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemsCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(itemsCategory);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ItemsCategoryExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
