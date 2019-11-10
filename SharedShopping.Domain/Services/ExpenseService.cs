using System;
using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class ExpenseService : AbstractService, IExpenseService
    {
        private readonly IExpenseRepository expenses;

        public ExpenseService(IExpenseRepository expenses) : base()
        {
            this.assert.isNotNull(expenses);

            this.expenses = expenses;
        }

        public IEnumerable<Debt> getCurrentDebtBalance()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Debt> getDebts(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> getExpenses()
        {
            return this.expenses
                .getExpenses()
                .map(map);
        }

        public void save(Expense expense)
        {
            this.assert.isNotNull(expense);
            this.expenses.set(expense.mapTo<ExpenseData>());
        }
    }
}