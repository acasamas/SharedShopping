using SharedShopping.Data.Models;
using SharedShopping.Data.Services.Generics;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IExpenseRepository : IAdditiveRepository<ExpenseData>
    {
        IEnumerable<FullExpense> getExpenses();
    }
}