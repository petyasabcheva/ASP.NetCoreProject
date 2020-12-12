namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;

    public class CreateWeddingInputModel
    {
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int Budget { get; set; }

        public string BrideName { get; set; }

        public string GroomName { get; set; }
    }
}
