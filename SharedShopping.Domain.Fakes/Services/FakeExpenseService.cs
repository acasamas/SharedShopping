using System;
using System.Collections.Generic;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Fakes.Services
{
    public class FakeExpenseService : IExpenseService
    {
        public FakeExpenseService()
        {
        }

        public IEnumerable<Debt> getCurrentDebtBalance()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Debt> getDebts(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Expense> getExpenses()
        {
            yield return buildExpense(1);

            throw new System.NotImplementedException();
        }

        public void save(Expense expense)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }

        private static Expense buildExpense(int id)
        {
            throw new NotImplementedException();
        }

    }
}