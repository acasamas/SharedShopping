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

        public TagData getOrCreateTag(string name)
        {
            TagData tagData;

            tagData = new TagData
            {
                Id = this.Tags.Count + 1,
                Name = name,
            };

            this.Tags.Add(tagData);
            return tagData;
        }

        public UserData getSingleUser(string userName)
        {
            return this.Users.Single(u => u.Name == userName);
        }

        public UserData getSingleUser(int userId)
        {
            return this.Users.Single(u => u.Id == userId);
        }

        public IEnumerable<TagData> getTags()
        {
            return this.Tags;
        }

        public IEnumerable<TagData> getTagsByExpense(int expenseId)
        {
            return this.TaggedExpenses
                .Where(mm => mm.ExpenseId == expenseId)
                .Join(this.Tags, mm => mm.TagId, tag => tag.Id, (mm, tag) => tag);
        }

        public IEnumerable<UserData> getUsers()
        {
            return this.Users;
        }

        public void save(ExpenseData expense)
        {
            ExpenseData data;

            data = this.Expenses.Single(e => e.Id == expense.Id);
            data.Concept = expense.Concept;
            data.Date = expense.Date;
        }

        public void save(UserData user)
        {
            UserData data;

            data = this.Users.Single(u => u.Id == user.Id);
            data.Name = user.Name;
        }

        public void saveOrCreate(TagData tag)
        {
            TagData data;

            data = this.Tags.Single(t => t.Id == tag.Id);
            data.Name = tag.Name;
        }

        public void setContribution(ContributionData contribution)
        {
            ContributionData data;

            data = this.Contributions.Single(c => c.ExpenseId == contribution.ExpenseId && c.UserId == contribution.UserId);
            data.Amount = contribution.Amount;
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
                this.TaggedExpenses.Add(new TaggedExpense
                {
                    ExpenseId = expenseId,
                    TagId = tagId,
                    Id = this.TaggedExpenses.Count + 1,
                });
        }
    }
}