namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public interface IGuestsService
    {
        Task CreateAsync(CreateGuestInputModel input, string userId);

        IEnumerable<GuestViewModel> GetAll(string userId, int side);
    }
}
