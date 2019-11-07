using System.Collections.Generic;
using System.Linq;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests.Fakes
{
    public class FakeRepository : IRepository
    {
        public FakeRepository()
        {
            this.Expenses = new List<ExpenseData>();
            this.Users = new List<UserData>();
            this.Contributions = new List<ContributionData>();
            this.Tags = new List<TagData>();
            this.Debtors = new List<DebtorData>();
            this.TaggedExpenses = new List<TaggedExpense>();
        }

        public IList<ExpenseData> Expenses { get; }
        public IList<UserData> Users { get; }
        public IList<ContributionData> Contributions { get; }
        public IList<TagData> Tags { get; }
        public IList<DebtorData> Debtors { get; }
        public IList<TaggedExpense> TaggedExpenses { get; }

        public void create(ExpenseData itemData)
        {
            this.Expenses.Add(itemData);
        }

        public void create(UserData dataItem)
        {
            this.Users.Add(dataItem);
        }

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

        public IEnumerable<ExpenseData> getExpensesByTag(int tagId)
        {
            return this.TaggedExpenses
                .Where(te => te.TagId == tagId)
                .Join(this.Expenses, te => te.ExpenseId, tag => tag.Id, (te, tag) => tag);
        }

        public IEnumerable<ExpenseData> getExpensesByUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public TagData getOrCreateTag(string name)
        {
            throw new System.NotImplementedException();
        }

        public UserData getSingleUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public UserData getSingleUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TagData> getTags()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TagData> getTagsByExpense(int id)
        {
            throw new System.NotImplementedException();
        }

        public void save(ExpenseData dataItem)
        {
            throw new System.NotImplementedException();
        }

        public void save(UserData dataItem)
        {
            throw new System.NotImplementedException();
        }

        public void saveOrCreate(TagData tag)
        {
            throw new System.NotImplementedException();
        }

        public void setContribution(ContributionData contributionData)
        {
            throw new System.NotImplementedException();
        }

        public void setDebtor(int expenseId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public void setExpenseTag(int expenseId, string tagName)
        {
            throw new System.NotImplementedException();
        }
    }
}