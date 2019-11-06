using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Internals
{
    internal class Expense : AbstractDomainModel<ExpenseData>, IExpense
    {
        public Expense(IValidator validate, IRepository repository, ExpenseData dataItem)
            : base(validate, repository, dataItem) { }

        public Expense(IValidator validate, IRepository repository
            , DateTime date, string concept, IEnumerable<NewContribution> contributions)
            : base(validate, repository, prv_buildData(repository, date, concept))
        {
            foreach (NewContribution contribution in contributions)
            {
                int userId;
                ContributionData contributionData;

                userId = this.repository.getSingleUser(contribution.UserName).Id.Value;

                contributionData = new ContributionData
                {
                    UserId = userId,
                    Amount = contribution.Amount,
                    ExpenseId = this.dataItem.Id.Value,
                };

                this.repository.setContribution(contributionData);
            }
        }

        public IEnumerable<IContribution> Contributions => this.repository
            .getContributionsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, Contribution>);

        public IEnumerable<IUser> Debtors => this.repository
            .getDebtorsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<UserData, User>);

        public string Concept
        {
            get => this.dataItem.Concept;
            set
            {
                this.validate.stringIsNotEmpty(value);
                this.dataItem.Concept = value;
                this.repository.save(this.dataItem);
            }
        }

        public DateTime Date => this.dataItem.Date;

        public IEnumerable<ITag> Tags => this.repository
            .getTagsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<TagData, Tag>);

        public int Id => this.dataItem.Id.Value;

        public void setDebtor(string userName)
        {
            UserData user;

            user = this.repository.getSingleUser(userName);
            this.repository.setDebtor(this.dataItem.Id.Value, user.Id.Value);
        }

        public void setTag(string tagName)
        {
            this.repository.setExpenseTag(this.dataItem.Id.Value, tagName);
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
