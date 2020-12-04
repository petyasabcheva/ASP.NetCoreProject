using MyWeddingPlanner.Data.Models;

namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Linq;

    using AutoMapper;
    using MyWeddingPlanner.Data.Models.Vendors;
    using MyWeddingPlanner.Services.Mapping;

    public class VendorInListViewModel 
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int[] ServicesIds { get; set; }

        public string[] ServicesNames { get; set; }

        public string Description { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Vendor, VendorInListViewModel>()
        //        .ForMember(x => x.Image, opt =>
        //            opt.MapFrom(x =>
        //                x.Images.FirstOrDefault()));
        //}
    }
}
