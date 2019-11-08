using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface ITaggedExpenseRepository : IAdditiveRepository<TaggedExpenseData>
    {
        IEnumerable<TagData> getTagsByExpense(int expenseId);
        IEnumerable<ExpenseData> getExpensesByTag(int tagId);
    }
}