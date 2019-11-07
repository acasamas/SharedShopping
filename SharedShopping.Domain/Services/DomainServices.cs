using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Services;
using SharedShopping.Domain.Validations;

namespace SharedShopping.Domain.Services
{
    public class DomainServices : IDomainServices
    {
        public DomainServices(IDomainValidator validator, IRepository repository)
        {
            this.Asserts = Blacksmith.Validations.Asserts.Assert;

            this.Asserts.isNotNull(validator);
            this.Asserts.isNotNull(repository);
            this.Validator = validator;
            this.Repository = repository;
        }

        public IRepository Repository { get; }
        public IValidator Asserts { get; }
        public IDomainValidator Validator { get; }
        public IDomainStrings Strings => this.Validator.Strings;
    }
}