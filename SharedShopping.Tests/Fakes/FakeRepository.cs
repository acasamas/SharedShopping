using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;

namespace SharedShopping.Tests.Fakes
{
    public class FakeRepository : IRepository
    {
        public FakeRepository()
        {
            this.Users = new List<UserData>();
            this.Contributions = new List<ContributionData>();
            this.Tags = new List<TagData>();
            this.Debtors = new List<DebtorData>();
            this.TaggedExpenses = new List<TaggedExpenseData>();
        }

        public IList<UserData> Users { get; }
        public IList<ContributionData> Contributions { get; }
        public IList<TagData> Tags { get; }
        public IList<DebtorData> Debtors { get; }
        public IList<TaggedExpenseData> TaggedExpenses { get; }

        public void create(UserData dataItem)
        {
            UserData data;

            dataItem.Id = this.Users.Count + 1;
            data = dataItem.mapTo<UserData>();
            this.Users.Add(data);
        }

        public void create(TagData tag)
        {
            TagData data;

            tag.Id = this.Tags.Count + 1;
            data = tag.mapTo<TagData>();
            this.Tags.Add(data);
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

        public TagData getSingleOrDefaultTag(string name)
        {
            return this.Tags
                .SingleOrDefault(t => t.Name == name)?
                .mapTo<TagData>();
        }

        public UserData getSingleUser(string userName)
        {
            return this.Users
                .Single(u => u.Name == userName)
                .mapTo<UserData>();
        }

        public UserData getSingleUser(int userId)
        {
            return this.Users
                .Single(u => u.Id == userId)
                .mapTo<UserData>();
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

        public void save(UserData user)
        {
            UserData data;

            data = this.Users.Single(u => u.Id == user.Id);
            user.mapTo(data);
        }

        public void save(TagData tag)
        {
            TagData data;

            data = this.Tags.Single(t => t.Id == tag.Id);
            tag.mapTo(data);
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