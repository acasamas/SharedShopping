using System;
using Blacksmith.Validations;
using SharedShopping.Domain.Localizations;

namespace SharedShopping.Domain.Validations
{
    public interface IDomainValidator : IValidator
    {
        IDomainStrings Strings { get; }

        void contribution_amount_is_positive(decimal amount);
        void date_must_be_after_year_1900(DateTime date);
    }
}