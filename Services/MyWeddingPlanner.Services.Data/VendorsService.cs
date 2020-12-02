namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Data.Models.Vendors;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class VendorsService : IVendorsService
    {
        private readonly IRepository<Vendor> vendorRepository;
        private readonly IDeletableEntityRepository<Service> serviceRepository;
        private readonly IRepository<VendorService> vendorServiceRepository;

        public VendorsService(
            IRepository<Vendor> vendorRepository,
            IDeletableEntityRepository<Service> serviceRepository,
            IRepository<VendorService> vendorServiceRepository)
        {
            this.vendorRepository = vendorRepository;
            this.serviceRepository = serviceRepository;
            this.vendorServiceRepository = vendorServiceRepository;
        }

        public async Task CreateAsync(CreateVendorInputModel input, string userId)
        {
            var vendor = new Vendor
            {
                Name = input.Name,
                Description = input.Description,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                WebPage = input.WebPage,
                UserId = userId,
            };


            foreach (var inputService in input.ReturnedServices)
            {
                var service = this.serviceRepository.All().FirstOrDefault(x => x.Id == inputService);

                if (service == null)
                {
                    service = new Service
                    {
                        Name = service.Name,
                    };
                }

                vendor.VendorServices.Add(new VendorService
                {
                    Service = service,
                    Vendor = vendor,
                });
            }

            await this.vendorRepository.AddAsync(vendor);
            await this.vendorRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var vendors = this.vendorRepository.AllAsNoTracking()
                .To<T>().ToList();
            return vendors;
        }

        public int GetCount()
        {
            return this.vendorRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var vendor = this.vendorRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return vendor;
        }
    }
}
