using Microsoft.AspNetCore.Mvc;
using MyWeddingPlanner.Web.ViewModels.Vendors;

namespace MyWeddingPlanner.Web.Controllers
{
    public class VendorController:BaseController
    {
        public IActionResult Create()
        {
            var viewModel = new CreateVendorInputModel();
            return this.View(viewModel);
        }
    }
}
