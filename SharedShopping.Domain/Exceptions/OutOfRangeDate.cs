using Blacksmith.Validations.Exceptions;
using System;

namespace SharedShopping.Domain.Exceptions
{
    public class OutOfRangeDate : DomainException
    {
        public OutOfRangeDate(DateTime minimumDate, DateTime triedValue) : base()
        {
            this.MinimumDate = minimumDate;
            this.TriedValue = triedValue;
        }

        public DateTime MinimumDate { get; }
        public DateTime TriedValue { get; }
    }
}