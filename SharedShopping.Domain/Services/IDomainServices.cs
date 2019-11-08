using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Validations;

namespace SharedShopping.Domain.Services
{
    public interface IDomainServices
    {
        IExpenseRepository Expenses { get; }
        IContributionRepository Contributions { get; }
        IDebtorRepository Debtors { get; }
        ITaggedExpenseRepository TaggedExpenses { get; }
        ITagRepository Tags { get; }
        IUserRepository Users { get; }
        IDomainStrings Strings { get; }
        IValidator Asserts { get; }
        IDomainValidator Validator { get; }
    }
}
