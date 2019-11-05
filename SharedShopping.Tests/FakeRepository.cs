using System.Collections.Generic;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests
{
    internal class FakeRepository : IRepository
    {
        private readonly IList<string> tags;
        private int tagsNextId;

        public FakeRepository()
        {
            this.tags = new List<string>();
            this.tagsNextId = 1;
        }

        public void create(TagData tagData)
        {
            throw new System.NotImplementedException();
        }

        public void create(ExpenseData itemData)
        {
            throw new System.NotImplementedException();
        }

        public void create(UserData dataItem)
        {
            throw new System.NotImplementedException();
        }

        public void create(ContributionData dataItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ContributionData> getContributionsByExpense(int expenseId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ContributionData> getContributionsByUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserData> getDebtorsByExpense(int expenseId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExpenseData> getExpensesByTag(int tagId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExpenseData> getExpensesByUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public TagData getOrCreateTag(string name)
        {
            this.tags.Add(name);
            return new TagData
            {
                Name = name,
                Id = this.tagsNextId++,
            };
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

        public void save(TagData dataItem)
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

        public void save(ContributionData dataItem)
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