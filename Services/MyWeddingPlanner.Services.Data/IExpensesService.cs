namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public interface IExpensesService
    {
        Task CreateAsync(string name, decimal totalAmount, decimal paidAmount, DateTime dueDate, string userId);

        IEnumerable<ExpenditureViewModel> GetAll(string userId);
    }
}
