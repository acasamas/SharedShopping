using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;

namespace SharedShopping.Domain.Services
{
    public interface IDomainCore : IValidator
    {
        IRepository Repository { get; }
        IDomainStrings Strings { get; }
        Asserts Assert { get; }

        void contribution_amount_is_positive(decimal amount);
    }
}
