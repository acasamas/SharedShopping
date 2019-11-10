using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests.Fakes
{
    public class FakeRepository
    {
        public IList<ContributionData> Contributions { get; }
        public IList<DebtorData> Debtors { get; }
        public IList<TaggedExpenseData> TaggedExpenses { get; }

        public IEnumerable<ContributionData> getContributionsByExpense(int expenseId)
        {
            return this.Contributions
                .Where(c => c.ExpenseId == expenseId);
        }

        public IEnumerable<ContributionData> getContributionsByUser(int id)
        {
            return this.Contributions
                .Where(c => c.UserId == id);
        }

        public IEnumerable<UserData> getDebtorsByExpense(int expenseId)
        {
            return this.Debtors
                .Where(e => e.ExpenseId == expenseId)
                .Join(this.Users, debtor => debtor.UserId, user => user.Id, (debtor, user) => user);
        }

        public IEnumerable<ExpenseData> getExpensesByDebtor(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExpenseData> getExpensesByTag(int tagId)
        {
            return this.TaggedExpenses
                .Where(mm => mm.TagId == tagId)
                .Join(this.Expenses, mm => mm.ExpenseId, expense => expense.Id, (mm, expense) => expense);
        }

        public IEnumerable<TagData> getTagsByExpense(int expenseId)
        {
            return this.TaggedExpenses
                .Where(mm => mm.ExpenseId == expenseId)
                .Join(this.Tags, mm => mm.TagId, tag => tag.Id, (mm, tag) => tag);
        }

        public void setContribution(ContributionData contribution)
        {
            ContributionData data;

            data = this.Contributions.SingleOrDefault(c => c.ExpenseId == contribution.ExpenseId && c.UserId == contribution.UserId);

            if (data != null)
                contribution.mapTo(data);
            else
            {
                contribution.Id = this.Contributions.Count;
                data = contribution.mapTo<ContributionData>();
                this.Contributions.Add(data);
            }
        }

        public void setDebtor(int expenseId, int userId)
        {
            bool existsEntry;

            existsEntry = this.Debtors.Any(mm => mm.ExpenseId == expenseId && mm.UserId == userId);

            if (false == existsEntry)
                this.Debtors.Add(new DebtorData
                {
                    UserId = userId,
                    ExpenseId = expenseId,
                    Id = this.Debtors.Count + 1,
                });
        }

        public void setExpenseTag(int expenseId, int tagId)
        {
            bool existsEntry;

            existsEntry = this.TaggedExpenses.Any(mm => mm.ExpenseId == expenseId && mm.TagId == tagId);

            if (false == existsEntry)
                this.TaggedExpenses.Add(new TaggedExpenseData
                {
                    ExpenseId = expenseId,
                    TagId = tagId,
                    Id = this.TaggedExpenses.Count + 1,
                });
        }
    }
}