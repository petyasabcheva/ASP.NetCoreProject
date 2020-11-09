using System;
using System.Collections.Generic;
using System.Text;
using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public class Expenditure : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime DueDate { get; set; }

    }
}
