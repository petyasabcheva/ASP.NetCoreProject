namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyWeddingPlanner.Data.Common.Models;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.MyWedding;
    using MyWeddingPlanner.Web.ViewModels.MyWedding;

    public class ExpensesService : IExpensesService
    {
        private readonly IDeletableEntityRepository<Expenditure> expendituresRepository;
        private readonly IRepository<Wedding> weddingRepository;

        public ExpensesService(IDeletableEntityRepository<Expenditure> expendituresRepository, IRepository<Wedding> weddingRepository)
        {
            this.expendituresRepository = expendituresRepository;
            this.weddingRepository = weddingRepository;
        }

        public async Task CreateAsync(string name, decimal totalAmount, decimal paidAmount, DateTime dueDate, string userId)
        {
            var expense = new Expenditure()
            {
                Name = name,
                TotalAmount = totalAmount,
                PaidAmount = paidAmount,
                DueDate = dueDate,
            };

            var wedding = this.weddingRepository.All().FirstOrDefault(x => x.OwnerId == userId);
            wedding.Expenditures.Add(expense);
            await this.weddingRepository.SaveChangesAsync();
        }

        public IEnumerable<ExpenditureViewModel> GetAll(string userId)
        {
            var guests = this.expendituresRepository.AllAsNoTracking()
                .Where(x => x.Wedding.OwnerId == userId).OrderBy(x => x.CreatedOn)
                .Select(x => new ExpenditureViewModel()
                {
                    Name = x.Name,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    DueDate = x.DueDate,
                }).ToList();
            return guests;
        }
    }
}
