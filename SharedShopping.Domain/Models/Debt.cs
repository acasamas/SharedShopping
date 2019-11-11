using SharedShopping.Domain.Exceptions;

namespace SharedShopping.Domain.Models
{
    public class Debt : AbstractAppDomain
    {
        public Debt(User debtor , User creditor, decimal amount)
        {
            this.assert.isNotNull(debtor);
            this.assert.isNotNull(creditor);
            isTrue<OutOfRangeAmount>(0 < amount);

            this.Debtor = debtor;
            this.Creditor = creditor;
            this.Amount = amount;
        }
        public User Debtor { get; }
        public decimal Amount { get; }
        public User Creditor { get; }
    }
}