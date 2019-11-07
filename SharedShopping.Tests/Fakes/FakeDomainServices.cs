using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Services;
using SharedShopping.Domain.Validations;

namespace SharedShopping.Tests.Fakes
{
    public class FakeDomainServices : IDomainServices
    {
        public FakeDomainServices()
        {
            this.FakeRepository = new FakeRepository();
            this.Asserts = Blacksmith.Validations.Asserts.Assert;
            this.Validator = new DomainValidator(new EsDomainStrings());
        }

        public IRepository Repository => this.FakeRepository;
        public FakeRepository FakeRepository { get; }

        public IDomainStrings Strings => this.Validator.Strings;
        public IValidator Asserts { get; }
        public IDomainValidator Validator { get; }
    }
}