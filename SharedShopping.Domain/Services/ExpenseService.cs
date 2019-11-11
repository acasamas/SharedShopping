using System;
using System.Collections.Generic;
using System.Linq;
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
            return this.expenses.map(map);
        }

        public void save(Expense expense)
        {
            FullExpense fullExpense;

            this.assert.isNotNull(expense);

            fullExpense = new FullExpense
            {
                Expense = map(expense),
                Tags = expense.Tags
                    .map<TagData>()
                    .ToList(),

                Debtors = expense.Debtors
                    .map<UserData>()
                    .ToList(),

                Contributions = expense.Contributions
                    .Select(map)
                    .ToList(),
            };

            this.expenses.set(fullExpense);
        }
    }
}