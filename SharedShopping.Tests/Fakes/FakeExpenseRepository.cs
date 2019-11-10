using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests.Fakes
{
    public class FakeExpenseRepository : IExpenseRepository
    {
        public FakeExpenseRepository()
        {
            this.Expenses = new List<ExpenseData>();
        }

        public ICollection<ExpenseData> Expenses { get; }

        public IEnumerator<ExpenseData> GetEnumerator()
        {
            return this.Expenses.GetEnumerator();
        }

        public IEnumerable<FullExpense> getExpenses()
        {
            throw new System.NotImplementedException();
        }

        public void set(ExpenseData data)
        {
            ExpenseData dbData;

            if (data.Id.HasValue)
            {
                dbData = this.Expenses.Single(e => e.Id == data.Id);
                data.mapTo(dbData);
            }
            else
            {
                data.Id = this.Expenses.Count + 1;
                dbData = data.mapTo<ExpenseData>();
                this.Expenses.Add(dbData);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Expenses.GetEnumerator();
        }
    }
}