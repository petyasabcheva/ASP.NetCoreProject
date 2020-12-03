﻿namespace MyWeddingPlanner.Web.Controllers
{
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
            var user = await this.userManager.GetUserAsync(this.User);

            await this.vendorService.CreateAsync(input, user.Id);

            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new VendorsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Vendors = this.vendorService.GetAll<VendorInListViewModel>(id, 12),
                ItemsCount = this.vendorService.GetCount(),
            };
            return this.View(viewModel);
        }

        // public IActionResult ById(int id)
        // {
        //    var vendor = this.vendorService.GetById<VendorViewModel>(id);
        //    return this.View(vendor);
        // }
    }
}