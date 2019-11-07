namespace SharedShopping.Domain.Models
{
    public class UserContribution
    {
        public IUser User { get; set; }
        public decimal Amount { get; set; }
    }
}