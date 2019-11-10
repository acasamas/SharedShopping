using Blacksmith.Validations.Exceptions;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Exceptions
{
    public class AlreadyAddedExpenseDebtor : DomainException
    {
        public AlreadyAddedExpenseDebtor(User user)
        {
            this.User = user;
        }

        public User User { get; }
    }
}