using System;
using System.Collections.Generic;
using System.Linq;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class Expense : AbstractDomainService<ExpenseData>, IExpense
    {
        public Expense(IDomainServices services, ExpenseData dataItem)
            : base(services, dataItem) { }

        public Expense(IDomainServices services
            , DateTime date, string concept, IEnumerable<UserContribution> contributions)
            : base(services, prv_buildData(services.Repository, date, concept))
        {
            foreach (UserContribution contribution in contributions)
            {
                ContributionData contributionData;

                this.services.Asserts.isInstanceOf<User>(contribution.User);

                contributionData = new ContributionData
                {
                    UserId = ((User)contribution.User).DataId,
                    Amount = contribution.Amount,
                    ExpenseId = this.dataItem.Id.Value,
                };

                this.services
                    .Repository
                    .setContribution(contributionData);
            }
        }

        public IEnumerable<IContribution> Contributions => this.services
            .Repository
            .getContributionsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, DomainContribution>);

        public IEnumerable<IUser> Debtors => this.services
            .Repository
            .getDebtorsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<UserData, User>);

        public string Concept
        {
            get => this.dataItem.Concept;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.Expense_concept_cannot_be_empty);
                this.dataItem.Concept = value;
                this.services.Repository.save(this.dataItem);
            }
        }

        public DateTime Date => this.dataItem.Date;

        public IEnumerable<ITag> Tags => this.services
            .Repository
            .getTagsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<TagData, Tag>);

        public int Id => this.dataItem.Id.Value;

        public void setDebtor(IUser user)
        {
            bool userIsAlreadyDebtor;
            int userId;

            this.services.Asserts.isInstanceOf<User>(user);

            userId = (user as User).DataId;

            userIsAlreadyDebtor = this.services
                .Repository
                .getDebtorsByExpense(this.DataId)
                .Any(u => u.Id == userId);

            this.services.Validator.isFalse(userIsAlreadyDebtor
                , this.services.Strings.User_is_already_a_debtor_of_expense(user.Name, this.DataId));

            this.services
                .Repository
                .setDebtor(this.dataItem.Id.Value, userId);
        }

        public void setTag(ITag tag)
        {
            this.services.Asserts.isInstanceOf<Tag>(tag);

            this.services
                .Repository
                .setExpenseTag(this.dataItem.Id.Value, (tag as Tag).DataId);
        }

        protected override void prv_validate(ExpenseData data)
        {
            this.services.Validator.stringIsNotEmpty(data.Concept, this.services.Strings.Expense_concept_cannot_be_empty);
            this.services.Validator.date_must_be_after_year_1900(data.Date);
        }

        private static ExpenseData prv_buildData(IRepository repository, DateTime date, string concept)
        {
            ExpenseData expenseData;

            expenseData = new ExpenseData
            {
                Date = date,
                Concept = concept,
            };

            repository.create(expenseData);
            return expenseData;
        }
    }
}
