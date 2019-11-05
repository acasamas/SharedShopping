using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Internals
{
    internal class User : AbstractDomainModel<UserData>, IUser
    {
        public User(IValidator validate, IRepository repository, UserData userData)
            :base (validate, repository, userData)
        {
        }

        public User(IValidator validate, IRepository repository, string name) : base(validate, repository)
        {
            UserData userData;

            userData = new UserData
            {
                Name = name,
            };

            this.repository.create(userData);
            prv_validate(userData);
            this.dataItem = userData;
        }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.validate.stringIsNotEmpty(value);
                this.dataItem.Name = value;
                this.repository.save(this.dataItem);
            }
        }

        public IEnumerable<IContribution> Contributions => this.repository
            .getContributionsByUser(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, Contribution>);

        public IEnumerable<IExpense> Expenses => this.repository
            .getExpensesByUser(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, Expense>);
        
        protected override void prv_validate(UserData userData)
        {
            this.assert.isNotNull(userData);
            this.assert.stringIsNotEmpty(userData.Name);
            this.assert.isTrue(userData.Id.HasValue, "User ID has no value.");
        }
    }
}