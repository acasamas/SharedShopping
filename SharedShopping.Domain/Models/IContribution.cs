namespace SharedShopping.Domain.Models
{
    public interface IContribution
    {
        IUser User { get; }
        decimal Amount { get; }
        IExpense Expense { get; }
    }
}
