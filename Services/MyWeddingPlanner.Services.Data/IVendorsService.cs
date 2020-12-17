namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public interface IVendorsService
    {
        Task CreateAsync(CreateVendorInputModel input, string userId, string imagePath);

        IEnumerable<VendorInListViewModel> GetAll(int page, int itemsPerPage);

        int GetCount();

        SingleVendorViewModel GetById(int id);

        IEnumerable<VendorInListViewModel> GetByCategory(int page, int itemsPerPage, int serviceId);
    }
}
