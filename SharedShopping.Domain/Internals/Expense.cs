using System;
using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class Expense : AbstractDomainModel<ExpenseData>, IExpense
    {
        public Expense(IDomainServices services, ExpenseData dataItem)
            : base(services, dataItem) { }

        public Expense(IDomainServices services
            , DateTime date, string concept, IEnumerable<NewContribution> contributions)
            : base(services, prv_buildData(services.Repository, date, concept))
        {
            foreach (NewContribution contribution in contributions)
            {
                int userId;
                ContributionData contributionData;

                userId = this.services
                    .Repository
                    .getSingleUser(contribution.UserName)
                    .Id
                    .Value;

                contributionData = new ContributionData
                {
                    UserId = userId,
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
            .map(prv_createDomainInstance<ContributionData, Contribution>);

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

        public void setDebtor(string userName)
        {
            UserData user;

            user = this.services
                .Repository
                .getSingleUser(userName);

            this.services
                .Repository
                .setDebtor(this.dataItem.Id.Value, user.Id.Value);
        }

        public void setTag(string tagName)
        {
            TagData tag;

            tag = this.services
                .Repository
                .getOrCreateTag(tagName);

            this.services
                .Repository
                .setExpenseTag(this.dataItem.Id.Value, tag.Id.Value);
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
