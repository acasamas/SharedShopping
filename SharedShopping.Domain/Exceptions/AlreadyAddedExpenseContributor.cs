using Blacksmith.Validations.Exceptions;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Exceptions
{
    public class AlreadyAddedExpenseContributor : DomainException
    {
        public AlreadyAddedExpenseContributor(Contribution contribution)
        {
            this.Contribution = contribution;
        }

        public Contribution Contribution { get; }
    }
}