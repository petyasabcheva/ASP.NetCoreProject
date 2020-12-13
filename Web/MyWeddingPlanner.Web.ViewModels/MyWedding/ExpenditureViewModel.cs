namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExpenditureViewModel
    {
        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal LeftAmount => this.TotalAmount - this.PaidAmount;

        public DateTime DueDate { get; set; }
    }
}
