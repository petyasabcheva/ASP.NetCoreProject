namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GuestListViewModel
    {
        public IEnumerable<GuestViewModel> BrideGuests { get; set; }

        public IEnumerable<GuestViewModel> GroomGuests { get; set; }

        public int Count => this.BrideGuests.Count() + this.GroomGuests.Count();
    }
}
