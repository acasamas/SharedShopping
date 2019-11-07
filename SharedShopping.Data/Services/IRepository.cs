using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IExpenseRepository
    {

    }
    public interface IRepository
    {
        void create(ExpenseData expense);
        void save(ExpenseData expense);
        void setDebtor(int expenseId, int userId);
        void setExpenseTag(int expenseId, int tagId);
        IEnumerable<UserData> getDebtorsByExpense(int expenseId);
        IEnumerable<ContributionData> getContributionsByExpense(int expenseId);
        void setContribution(ContributionData contribution);
        IEnumerable<TagData> getTagsByExpense(int expenseId);
        
        void create(UserData user);
        void save(UserData user);
        IEnumerable<ExpenseData> getExpensesByDebtor(int userId);
        IEnumerable<ContributionData> getContributionsByUser(int userId);
        UserData getSingleUser(string userName);
        UserData getSingleUser(int userId);
        
        void saveOrCreate(TagData tag);
        TagData getOrCreateTag(string name);
        IEnumerable<ExpenseData> getExpensesByTag(int tagId);
        IEnumerable<TagData> getTags();
    }
}