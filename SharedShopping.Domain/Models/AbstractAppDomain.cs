using Blacksmith.Validations;
using SharedShopping.Domain.Exceptions;
using System;

namespace SharedShopping.Domain.Models
{
    public abstract class AbstractAppDomain : AbstractDomain
    {
        protected static DateTime minimalDate = new DateTime(1990, 1, 1);

        protected void dateIsValid(DateTime date)
        {
            isTrue(minimalDate <= date, () => new OutOfRangeDateDomainException(minimalDate, date));
        }


    }
}