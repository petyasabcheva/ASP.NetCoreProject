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
    using MyWeddingPlanner.Data.Models.Vendors;

    [Area("Administration")]
    public class ServicesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Service> dataRepository;

        public ServicesController(IDeletableEntityRepository<Service> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/Services
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.All().ToListAsync());
        }

        // GET: Administration/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var service = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return this.NotFound();
            }

            return this.View(service);
        }

        // GET: Administration/Services/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Service service)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(service);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(service);
        }

        // GET: Administration/Services/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var service = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return this.NotFound();
            }

            return this.View(service);
        }

        // POST: Administration/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Service service)
        {
            if (id != service.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(service);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ServiceExists(service.Id))
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

            return this.View(service);
        }

        // GET: Administration/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var service = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return this.NotFound();
            }

            return this.View(service);
        }

        // POST: Administration/Services/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(service);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ServiceExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
