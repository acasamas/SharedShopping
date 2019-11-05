using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IRepository
    {
        void create(TagData tagData);
        void create(ExpenseData itemData);
        void create(UserData dataItem);
        void create(ContributionData dataItem);
        void save(TagData dataItem);
        void save(ExpenseData dataItem);
        void save(UserData dataItem);
        void save(ContributionData dataItem);
        TagData getOrCreateTag(string name);
        IEnumerable<ExpenseData> getExpensesByTag(int tagId);
        IEnumerable<ContributionData> getContributionsByExpense(int expenseId);
        IEnumerable<UserData> getDebtorsByExpense(int expenseId);
        IEnumerable<TagData> getTagsByExpense(int id);
        IEnumerable<ContributionData> getContributionsByUser(int id);
        IEnumerable<ExpenseData> getExpensesByUser(int id);
        UserData getSingleUser(string userName);
        UserData getSingleUser(int userId);
        IEnumerable<TagData> getTags();
        void setContribution(ContributionData contributionData);
        void setDebtor(int expenseId, int userId);
        void setExpenseTag(int expenseId, string tagName);
    }
}