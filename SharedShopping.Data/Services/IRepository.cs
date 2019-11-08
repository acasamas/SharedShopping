using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IRepository
    {
        //expense
        void create(ExpenseData expense);
        void save(ExpenseData expense);

        //user
        void create(UserData user);
        void save(UserData user);
        UserData getSingleUser(string userName);
        UserData getSingleUser(int userId);
        IEnumerable<UserData> getUsers();

        //tag
        void create(TagData tag);
        void save(TagData tag);
        TagData getSingleOrDefaultTag(string name);
        IEnumerable<TagData> getTags();

        //deb: expense-user
        void setDebtor(int expenseId, int userId);
        IEnumerable<UserData> getDebtorsByExpense(int expenseId);
        IEnumerable<ExpenseData> getExpensesByDebtor(int userId);

        //tag-expense
        void setExpenseTag(int expenseId, int tagId);
        IEnumerable<TagData> getTagsByExpense(int expenseId);
        IEnumerable<ExpenseData> getExpensesByTag(int tagId);

        //contribution: expense-user
        void setContribution(ContributionData contribution);
        IEnumerable<ContributionData> getContributionsByExpense(int expenseId);
        IEnumerable<ContributionData> getContributionsByUser(int userId);
        
    }
}