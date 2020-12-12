namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public interface IWeddingService
    {
        WeddingViewModel GetWedding(string userId);

        Task CreateAsync(CreateWeddingInputModel input, string userId);
    }
}
