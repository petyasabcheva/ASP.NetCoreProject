namespace MyWeddingPlanner.Data.Models.MyWedding
{
    using System;

    using MyWeddingPlanner.Data.Common.Models;

    public class Expenditure : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime DueDate { get; set; }
    }
}
