namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BudgetViewModel
    {
        public IEnumerable<ExpenditureViewModel> Expenditures { get; set; }

        public decimal Total => this.Expenditures.Sum(x => x.TotalAmount);

        public decimal TotalPaid => this.Expenditures.Sum(x => x.PaidAmount);

        public decimal TotalLeft => this.Expenditures.Sum(x => x.LeftAmount);

        public int Budget { get; set; }
    }
}
