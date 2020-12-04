using System.Security.Cryptography.X509Certificates;

namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Data.Models.Vendors;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class VendorsService : IVendorsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "JPG" };
        private readonly IRepository<Vendor> vendorRepository;
        private readonly IDeletableEntityRepository<Service> serviceRepository;

        public VendorsService(
            IRepository<Vendor> vendorRepository,
            IDeletableEntityRepository<Service> serviceRepository)
        {
            this.vendorRepository = vendorRepository;
            this.serviceRepository = serviceRepository;
        }

        public async Task CreateAsync(CreateVendorInputModel input, string userId, string imagePath)
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

            Directory.CreateDirectory($"{imagePath}/vendors/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };
                vendor.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/vendors/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.vendorRepository.AddAsync(vendor);
            await this.vendorRepository.SaveChangesAsync();
        }

        public IEnumerable<VendorInListViewModel> GetAll(int page, int itemsPerPage)
        {
            var vendors = this.vendorRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new VendorInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ServicesIds = x.VendorServices.Select(x => x.ServiceId).ToArray(),
                    ServicesNames = x.VendorServices.Select(x => x.Service.Name).ToArray(),
                    ImageUrl =
                        "/images/vendors/" + x.Images.FirstOrDefault().Id + '.' + x.Images.FirstOrDefault().Extension,
                }).ToList();
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
