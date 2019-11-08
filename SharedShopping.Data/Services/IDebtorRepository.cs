using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IDebtorRepository : IAdditiveRepository<DebtorData>
    {
        IEnumerable<UserData> getDebtorUsersByExpense(int expenseId);
        IEnumerable<ExpenseData> getExpensesByDebtorUser(int userId);
    }
}