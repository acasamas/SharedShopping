using System.Collections.Generic;
using System.Text;

namespace SharedShopping.Domain.Models
{
    public interface IUser
    {
        string Name { get; set; }
        IEnumerable<IContribution> Contributions { get; }
        IEnumerable<IExpense> Expenses { get; }
    }
}
