using Blacksmith.Validations.Exceptions;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Exceptions
{
    public class AlreadyAddedExpenseTag : DomainException
    {
        public AlreadyAddedExpenseTag(Tag tag)
        {
            this.Tag = tag;
        }

        public Tag Tag { get; }
    }
}