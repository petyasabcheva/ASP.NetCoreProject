namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Marketplace;
    using MyWeddingPlanner.Data.Models.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;
    using MyWeddingPlanner.Web.ViewModels.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class WeddingService : IWeddingService
    {
        private readonly IRepository<Wedding> weddingRepository;

        public WeddingService(IRepository<Wedding> weddingRepository)
        {
            this.weddingRepository = weddingRepository;
        }

        public WeddingViewModel GetWedding(string userId)
        {
            if (!this.weddingRepository.AllAsNoTracking().Any(x => x.OwnerId == userId))
            {
                return null;
            }

            var wedding = this.weddingRepository.AllAsNoTracking()
                .Where(x => x.OwnerId == userId)
                .Select(x => new WeddingViewModel()
                {
                    Location = x.Location,
                    OwnerId = x.OwnerId,
                    Budget = x.Budget,
                    Date = x.Date,
                    BrideName = x.BrideName,
                    GroomName = x.GroomName,
                    Guests = x.Guests.Count,
                    Tasks = x.ToDos.Where(x => x.Completed == false).Count(),
                }).FirstOrDefault();
            return wedding;
        }

        public async Task CreateAsync(CreateWeddingInputModel input, string userId)
        {
            var wedding = new Wedding()
            {
                BrideName = input.BrideName,
                GroomName = input.GroomName,
                Location = input.Location,
                Date = input.Date,
                Budget = input.Budget,
                OwnerId = userId,
            };

            await this.weddingRepository.AddAsync(wedding);
            await this.weddingRepository.SaveChangesAsync();
        }
    }
}
