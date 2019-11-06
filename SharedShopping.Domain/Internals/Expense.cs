using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;
using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Internals
{
    internal class Expense : AbstractDomainModel<ExpenseData>, IExpense
    {
        public Expense(IDomainCore domainCore, ExpenseData dataItem)
            : base(domainCore, dataItem) { }

        public Expense(IDomainCore domainCore
            , DateTime date, string concept, IEnumerable<NewContribution> contributions)
            : base(domainCore, prv_buildData(domainCore.Repository, date, concept))
        {
            foreach (NewContribution contribution in contributions)
            {
                int userId;
                ContributionData contributionData;

                userId = this.domainCore
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

                this.domainCore
                    .Repository
                    .setContribution(contributionData);
            }
        }

        public IEnumerable<IContribution> Contributions => this.domainCore
            .Repository
            .getContributionsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, Contribution>);

        public IEnumerable<IUser> Debtors => this.domainCore
            .Repository
            .getDebtorsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<UserData, User>);

        public string Concept
        {
            get => this.dataItem.Concept;
            set
            {
                this.domainCore.stringIsNotEmpty(value, this.domainCore.Strings.Expense_concept_cannot_be_empty);
                this.dataItem.Concept = value;
                this.domainCore.Repository.save(this.dataItem);
            }
        }

        public DateTime Date => this.dataItem.Date;

        public IEnumerable<ITag> Tags => this.domainCore
            .Repository
            .getTagsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<TagData, Tag>);

        public int Id => this.dataItem.Id.Value;

        public void setDebtor(string userName)
        {
            UserData user;

            user = this.domainCore
                .Repository
                .getSingleUser(userName);

            this.domainCore
                .Repository
                .setDebtor(this.dataItem.Id.Value, user.Id.Value);
        }

        public void setTag(string tagName)
        {
            this.domainCore
                .Repository
                .setExpenseTag(this.dataItem.Id.Value, tagName);
        }

        protected override void prv_validate(ExpenseData data)
        {
            this.validate.stringIsNotEmpty(data.Concept);
            this.validate.isTrue(data.Date > new DateTime(2000, 1, 1)
                , "La fecha no puede ser inferior al año 2000.");
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
