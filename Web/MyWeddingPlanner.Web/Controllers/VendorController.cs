namespace MyWeddingPlanner.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class VendorController : BaseController
    {
        private readonly IVendorsService vendorService;
        private readonly IServicesService servicesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public VendorController(
            IVendorsService vendorService,
            IServicesService servicesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.vendorService = vendorService;
            this.servicesService = servicesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateVendorInputModel();
            viewModel.Services = this.servicesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateVendorInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.vendorService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/Vendor/All");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new VendorsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Vendors = this.vendorService.GetAll(id, 12),
                ItemsCount = this.vendorService.GetCount(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var vendor = this.vendorService.GetById(id);
            return this.View(vendor);
        }

        [Authorize]
        public IActionResult Category(int serviceId, string service)
        {
            const int itemsPerPage = 12;
            var viewModel = new VendorsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = 1,
                Vendors = this.vendorService.GetByCategory(1, 12, serviceId),
                ItemsCount = this.vendorService.GetCount(),
                CategoryName = service,
            };
            return this.View(viewModel);
        }
    }
}
