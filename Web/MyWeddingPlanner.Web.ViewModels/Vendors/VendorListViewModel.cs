namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    using System.Collections.Generic;

    public class VendorListViewModel
    {
        public VendorListViewModel()
        {
            this.Vendors=new List<VendorViewModel>();
        }

        public ICollection<VendorViewModel> Vendors { get; set; }

        public int VendorsCount { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Vendor, VendorListViewModel>()
        //        .ForMember(x => x.ImageUrl, opt =>
        //            opt.MapFrom(x =>
        //                x.Images.FirstOrDefault().RemoteImageUrl != null ?
        //                    x.Images.FirstOrDefault().RemoteImageUrl :
        //                    "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        //}
    }
}
