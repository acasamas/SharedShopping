using Blacksmith.Validations.Localizations;

namespace SharedShopping.Domain.Localizations
{
    public interface IDomainStrings : IValidatorStrings
    {
        string Contribution_amount_is_positive { get; }
        string Expense_concept_cannot_be_empty { get; }
        string Tag_name_cannot_be_empty { get; }
        string Data_object_has_no_id { get; }
        string User_name_cannot_be_empty { get; }
        string Expense_date_must_be_after_year_1900 { get; }

        string User_is_already_a_debtor_of_expense(string name, int expenseId);
    }
}
