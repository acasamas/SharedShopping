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
            this.Expenses = new List<FullExpense>();
        }

        public IList<FullExpense> Expenses { get; }

        public IEnumerator<FullExpense> GetEnumerator()
        {
            return this.Expenses.GetEnumerator();
        }

        public void set(FullExpense data)
        {
            this.Expenses.Add(data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Expenses.GetEnumerator();
        }
    }
}