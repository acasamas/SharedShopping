using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public abstract class AbstractService : AbstractAppDomain
    {
        protected static ExpenseData map(Expense model)
        {
            return new ExpenseData
            {
                Date = model.Date,
                Concept = model.Concept,
            };
        }

        protected static Tag map(TagData data)
        {
            return new Tag(data.Name);
        }

        protected static User map(UserData data)
        {
            return new User(data.Name);
        }

        protected Expense map(FullExpense data)
        {
            Expense expense;
            IEnumerable<Contribution> contributions;

            contributions = data
                .Contributions
                .map(map);

            expense = data.Expense
                .mapTo(e => new Expense(e.Id.Value, e.Date, e.Concept, contributions));

            data.Debtors
                .map(map)
                .ToList()
                .ForEach(expense.setDebtor);

            data.Tags
                .map(map)
                .ToList()
                .ForEach(expense.setTag);

            return expense;
        }

        protected Contribution map(ExpenseContribution data)
        {
            return new Contribution(data.User.mapTo(map), data.Amount);
        }

        protected ExpenseContribution map(Contribution data)
        {
            return new ExpenseContribution
            {
                User = data.User.mapTo<UserData>(),
                Amount = data.Amount,
            };
        }

    }
}
