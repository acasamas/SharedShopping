using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Validations;

namespace SharedShopping.Domain.Services
{
    public interface IDomainServices
    {
        IRepository Repository { get; }
        IDomainStrings Strings { get; }
        IValidator Asserts { get; }
        IDomainValidator Validator { get; }
    }
}
