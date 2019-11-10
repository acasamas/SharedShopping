using SharedShopping.Domain.Exceptions;
using System;

namespace SharedShopping.Domain.Models
{
    public class Contribution : AbstractAppDomain, IEquatable<Contribution>
    {
        public Contribution(User user, decimal amount)
        {
            this.assert.isNotNull(user);
            isTrue<OutOfRangeUserContribution>(0 < amount);

            this.User = user;
            this.Amount = amount;
        }

        public User User { get; }
        public decimal Amount { get; }

        public bool Equals(Contribution other)
        {
            return this.User.Equals(other.User);
        }
    }
}
