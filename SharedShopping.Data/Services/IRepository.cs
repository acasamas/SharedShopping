using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IRepository
    {
        void create(ExpenseData itemData);
        void save(ExpenseData dataItem);
        IEnumerable<ExpenseData> getExpensesByTag(int tagId);
        IEnumerable<ExpenseData> getExpensesByUser(int id);
        void setDebtor(int expenseId, int userId);
        void setExpenseTag(int expenseId, string tagName);
        
        void create(UserData dataItem);
        void save(UserData dataItem);
        IEnumerable<UserData> getDebtorsByExpense(int expenseId);
        UserData getSingleUser(string userName);
        UserData getSingleUser(int userId);
        
        void create(ContributionData dataItem);
        void save(ContributionData dataItem);
        IEnumerable<ContributionData> getContributionsByExpense(int expenseId);
        IEnumerable<ContributionData> getContributionsByUser(int id);
        void setContribution(ContributionData contributionData);

        void saveOrCreate(TagData tag);
        TagData getOrCreateTag(string name);
        IEnumerable<TagData> getTagsByExpense(int id);
        IEnumerable<TagData> getTags();
    }
}