using System;
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
            : base(validate, repository, userData) { }

        public User(IValidator validate, IRepository repository, string name)
            : base(validate, repository, prv_buildData(repository, name)) { }

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
            this.assert.stringIsNotEmpty(userData.Name);
            this.assert.isTrue(userData.Id.HasValue, "User ID has no value.");
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