using SharedShopping.Domain.Models;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> getTags();
        IEnumerable<Expense> getExpensesByTag(Tag tag);
    }
}
