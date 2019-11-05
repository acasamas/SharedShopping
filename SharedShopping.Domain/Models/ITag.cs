using System.Collections.Generic;

namespace SharedShopping.Domain.Models
{
    public interface ITag
    {
        string Name { get; set; }
        IEnumerable<IExpense> Expenses { get; }
    }
}