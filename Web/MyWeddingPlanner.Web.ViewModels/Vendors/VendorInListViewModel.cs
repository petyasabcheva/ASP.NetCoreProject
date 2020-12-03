namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Linq;

    using AutoMapper;
    using MyWeddingPlanner.Data.Models.Vendors;
    using MyWeddingPlanner.Services.Mapping;

    public class VendorInListViewModel : IMapFrom<Vendor>
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Vendor, VendorInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/images/vendors/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
