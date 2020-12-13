namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeddingViewModel
    {
        public string OwnerId { get; set; }

        public DateTime Date { get; set; }

        public int TimeLeft => (this.Date - DateTime.Now).Days;

        public string Location { get; set; }

        public int Budget { get; set; }

        public string BrideName { get; set; }

        public string GroomName { get; set; }

        public int Guests { get; set; }

        public int Tasks { get; set; }
    }
}
