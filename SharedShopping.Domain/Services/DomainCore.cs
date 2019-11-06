using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Services
{
    public class DomainCore : AbstractDomainValidator, IDomainCore
    {
        public DomainCore(IDomainStrings strings, IRepository repository) : base(strings)
        {
            this.Assert = Asserts.Assert;

            this.Assert.isNotNull(strings);
            this.Assert.isNotNull(repository);
            this.Strings = strings;
            this.Repository = repository;
        }

        public IRepository Repository { get; }
        public IDomainStrings Strings { get; }
        public Asserts Assert { get; }

        public void contribution_amount_is_positive(decimal amount)
        {
            isTrue(amount > 0, this.Strings.Contribution_amount_is_positive);
        }
    }
}