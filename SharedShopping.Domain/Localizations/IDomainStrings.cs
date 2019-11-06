using Blacksmith.Validations.Localizations;

namespace SharedShopping.Domain.Localizations
{
    public interface IDomainStrings : IValidatorStrings
    {
        string Contribution_amount_is_positive { get; }
        string Expense_concept_cannot_be_empty { get; }
    }
}
