using SharedShopping.Domain.Models;
using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface IExpenseService
    {
        void save(Expense expense);
        IEnumerable<Debt> getCurrentDebtBalance();
        IEnumerable<Expense> getExpenses();
    }
}
