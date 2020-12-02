namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public interface IVendorsService
    {
        Task CreateAsync(CreateVendorInputModel input, string userId);

        IEnumerable<T> GetAll<T>();

        int GetCount();

        T GetById<T>(int id);
    }
}
