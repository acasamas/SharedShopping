using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class User : AbstractDomainModel<UserData>, IUser
    {
        public User(IDomainServices services, UserData userData)
            : base(services, userData) { }

        public User(IDomainServices services, string name)
            : base(services, prv_buildData(services.Repository, name)) { }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.User_name_cannot_be_empty);
                this.dataItem.Name = value;
                this.services.Repository.save(this.dataItem);
            }
        }

        public IEnumerable<IContribution> Contributions => this.services
            .Repository
            .getContributionsByUser(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, Contribution>);

        public IEnumerable<IExpense> ExpensesAsDebtor => this.services
            .Repository
            .getExpensesByDebtor(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, Expense>);

        public IEnumerable<Debt> Debts => throw new System.NotImplementedException();

        protected override void prv_validate(UserData userData)
        {
            this.services.Asserts.stringIsNotEmpty(userData.Name, this.services.Strings.User_name_cannot_be_empty);
            this.services.Asserts.isTrue(userData.Id.HasValue, this.services.Strings.Data_object_has_no_id);
        }

        private static UserData prv_buildData(IRepository repository, string name)
        {
            UserData userData;

            userData = new UserData
            {
                Name = name,
            };

            repository.create(userData);
            return userData;
        }
    }
}