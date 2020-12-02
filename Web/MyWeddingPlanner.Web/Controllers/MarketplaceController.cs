namespace MyWeddingPlanner.Web.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Services.Data;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;

    public class MarketplaceController:Controller
    {
        private readonly IVendorsService marketplaceService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public MarketplaceController(
            IVendorsService marketplaceService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.marketplaceService = marketplaceService;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateItemInputModel();
            return this.View(viewModel);
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Create(CreateVendorInputModel input)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(input);
        //    }

        //    // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var user = await this.userManager.GetUserAsync(this.User);

        //    try
        //    {
        //        await this.vendorService.CreateAsync(input, user.Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ModelState.AddModelError(string.Empty, ex.Message);
        //        return this.View(input);
        //    }

        //    // TODO: Redirect to recipe info page
        //    return this.Redirect("/");
        //}
    }
}
