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
            this.FakeExpenseRepository = new FakeExpenseRepository();
            this.Asserts = Blacksmith.Validations.Asserts.Assert;
            this.Validator = new DomainValidator(new EsDomainStrings());
        }

        public IExpenseRepository Expenses => this.FakeExpenseRepository;
        public FakeExpenseRepository FakeExpenseRepository { get; }

        public IDomainStrings Strings => this.Validator.Strings;
        public IValidator Asserts { get; }
        public IDomainValidator Validator { get; }
    }
}