using System.Collections.Generic;

namespace SharedShopping.Domain.Models
{
    public interface IUser
    {
        string Name { get; set; }
        IEnumerable<IContribution> Contributions { get; }
        IEnumerable<IExpense> ExpensesAsDebtor { get; }
        IEnumerable<Debt> Debts { get; }
    }
}
