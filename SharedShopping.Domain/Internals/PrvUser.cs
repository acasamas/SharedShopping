﻿using System;
using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class PrvUser : PrvAbstractDomainService<UserData>, IUser
    {
        public PrvUser(IDomainServices services, UserData userData)
            : base(services, userData) { }

        public PrvUser(IDomainServices services, string name)
            : base(services, prv_buildData(services.Users, name)) { }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.User_name_cannot_be_empty);
                this.dataItem.Name = value;
                this.services.Users.set(this.dataItem);
            }
        }

        public IEnumerable<IContribution> Contributions => this.services
            .Contributions
            .getByUser(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, PrvContribution>);

        public IEnumerable<IExpense> ExpensesAsDebtor => this.services
            .Debtors
            .getExpensesByDebtorUser(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, PrvExpense>);

        public IEnumerable<Debt> Debts => base.prv_computeDebtBalance()
            .Where(debt => debt.Debtor.Name == this.dataItem.Name);

        protected override void prv_validate(UserData userData)
        {
            this.services.Asserts.stringIsNotEmpty(userData.Name, this.services.Strings.User_name_cannot_be_empty);
            this.services.Asserts.isTrue(userData.Id.HasValue, this.services.Strings.Data_object_has_no_id);
        }

        private static UserData prv_buildData(IUserRepository repository, string name)
        {
            UserData userData;

            userData = new UserData
            {
                Name = name,
            };

            repository.set(userData);
            return userData;
        }
    }
}