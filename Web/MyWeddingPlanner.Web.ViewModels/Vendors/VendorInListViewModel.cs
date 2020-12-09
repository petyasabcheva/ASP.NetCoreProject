namespace MyWeddingPlanner.Web.ViewModels.Vendors
{
    public class VendorInListViewModel : SingleVendorViewModel
    {
        public string ImageUrl { get; set; }

        public int[] ServicesIds { get; set; }

        // public void CreateMappings(IProfileExpression configuration)
        // {
        //    configuration.CreateMap<Vendor, VendorInListViewModel>()
        //        .ForMember(x => x.Image, opt =>
        //            opt.MapFrom(x =>
        //                x.Images.FirstOrDefault()));
        // }
    }
}
