using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Validations;

namespace SharedShopping.Domain.Services
{
    public class DomainServices : IDomainServices
    {
        public DomainServices(IDomainValidator validator
            , IExpenseRepository expenses
            , IContributionRepository contributions
            , IDebtorRepository debtors
            , ITaggedExpenseRepository taggedExpenses
            , ITagRepository tags
            , IUserRepository users)
        {
            this.Asserts = Blacksmith.Validations.Asserts.Assert;

            this.Asserts.isNotNull(validator);
            this.Asserts.isNotNull(expenses);
            this.Asserts.isNotNull(contributions);
            this.Asserts.isNotNull(debtors);
            this.Asserts.isNotNull(taggedExpenses);
            this.Asserts.isNotNull(tags);
            this.Asserts.isNotNull(users);

            this.Expenses = expenses;
            this.Contributions = contributions;
            this.Debtors = debtors;
            this.TaggedExpenses = taggedExpenses;
            this.Tags = tags;
            this.Users = users;
            this.Validator = validator;
        }

        public IExpenseRepository Expenses { get; }
        public IContributionRepository Contributions { get; }
        public IDebtorRepository Debtors { get; }
        public ITaggedExpenseRepository TaggedExpenses { get; }
        public ITagRepository Tags { get; }
        public IUserRepository Users { get; }
        public IValidator Asserts { get; }
        public IDomainValidator Validator { get; }
        public IDomainStrings Strings => this.Validator.Strings;
    }
}