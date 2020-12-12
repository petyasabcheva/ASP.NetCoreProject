namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;
    using MyWeddingPlanner.Web.ViewModels.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class GuestsService : IGuestsService
    {
        private readonly IRepository<Guest> guestRepository;
        private readonly IRepository<Wedding> weddingRepository;

        public GuestsService(IRepository<Guest> guestRepository, IRepository<Wedding> weddingRepository)
        {
            this.guestRepository = guestRepository;
            this.weddingRepository = weddingRepository;
        }

        public async Task CreateAsync(CreateGuestInputModel input, string userId)
        {
            var guest = new Guest()
            {
                FullName = input.FullName,
                Table = input.Table,
                Side = (GuestSide)input.Side,
            };

            var wedding = this.weddingRepository.All().FirstOrDefault(x => x.OwnerId == userId);
            wedding.Guests.Add(guest);

            await this.weddingRepository.SaveChangesAsync();
        }

        public IEnumerable<GuestViewModel> GetAll(string userId, int side)
        {
            var wedding = this.weddingRepository.All().FirstOrDefault(x => x.OwnerId == userId);
            var guests = this.guestRepository.AllAsNoTracking()
                .Where(x => x.Side == (GuestSide)side && wedding.OwnerId == userId)
                .Select(x => new GuestViewModel()
                {
                    FullName = x.FullName,
                    Table = x.Table,
                }).ToList();
            return guests;
        }
    }
}
