using System;
using Blacksmith.Validations;
using SharedShopping.Domain.Localizations;

namespace SharedShopping.Domain.Validations
{
    public class DomainValidator : AbstractDomainValidator, IDomainValidator
    {
        public DomainValidator(IDomainStrings strings) : base(strings)
        {
            this.Strings = strings;
        }

        public IDomainStrings Strings { get; }

        public void contribution_amount_is_positive(decimal amount)
        {
            isTrue(amount > 0, this.Strings.Contribution_amount_is_positive);
        }

        public void date_must_be_after_year_1900(DateTime date)
        {
            isTrue(date > new DateTime(1900, 1, 1), this.Strings.Expense_date_must_be_after_year_1900);
        }
    }
}
