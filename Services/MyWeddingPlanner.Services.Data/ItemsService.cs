namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models;
    using MyWeddingPlanner.Data.Models.Marketplace;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Marketplace;
    using MyWeddingPlanner.Web.ViewModels.Vendors;

    public class ItemsService : IItemsService
    {
        private readonly IRepository<ItemForSale> itemsRepository;
        private readonly IDeletableEntityRepository<ItemsCategory> categoryRepository;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "JPG" };

        public ItemsService(IRepository<ItemForSale> itemsRepository, IDeletableEntityRepository<ItemsCategory> categoryRepository)
        {
            this.itemsRepository = itemsRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CreateItemInputModel input, string userId, string imagePath)
        {
            var item = new ItemForSale()
            {
                Name = input.Name,
                Description = input.Description,
                Price=input.Price,
                UserId = userId,
            };

            var category = this.categoryRepository.All().FirstOrDefault(x => x.Id == input.CategoryId);
            item.Category = category;

            Directory.CreateDirectory($"{imagePath}/itemsForSale/");
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
                    UserId = userId,
                };
                item.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/itemsForSale/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.itemsRepository.AddAsync(item);
            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<ItemsInListViewModel> GetAll(int page, int itemsPerPage)
        {
            var items = this.itemsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ItemsInListViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    ImageUrl =
                        "/images/itemsForSale/" + x.Images.FirstOrDefault().Id + '.' + x.Images.FirstOrDefault().Extension,
                }).ToList();
            return items;
        }

        public int GetCount()
        {
            return this.itemsRepository.All().Count();
        }

        public SingleItemViewModel GetById(int id)
        {
            var item = this.itemsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ItemsInListViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    ImageUrls = x.Images.Select(x => $"/images/itemsForSale/{x.Id}.{x.Extension}").ToArray(),
                    Description = x.Description,
                    SellerEmail = x.User.Email,
                }).FirstOrDefault();

            return item;
        }

        public IEnumerable<ItemsInListViewModel> GetByCategory(int page, int itemsPerPage, int categoryId)
        {
            var items = this.itemsRepository
                .AllAsNoTracking().Where(i => i.Category.Id == categoryId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ItemsInListViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    ImageUrl =
                        "/images/itemsForSale/" + x.Images.FirstOrDefault().Id + '.' + x.Images.FirstOrDefault().Extension,
                }).ToList();
            return items;
        }
    }
}
