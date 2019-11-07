namespace SharedShopping.Domain.Models
{
    public class Debt
    {
        public IUser Debtor { get; set; }
        public decimal Amount { get; set; }
        public IUser Creditor { get; set; }
    }
}