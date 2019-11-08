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
    internal class PrvExpense : PrvAbstractDomainService<ExpenseData>, IExpense
    {
        public PrvExpense(IDomainServices services, ExpenseData dataItem)
            : base(services, dataItem) { }

        public PrvExpense(IDomainServices services
            , DateTime date, string concept, IEnumerable<UserContribution> contributions)
            : base(services, prv_buildData(services.Expenses, date, concept))
        {
            foreach (UserContribution contribution in contributions)
            {
                ContributionData contributionData;

                this.services.Asserts.isInstanceOf<PrvUser>(contribution.User);

                contributionData = new ContributionData
                {
                    UserId = ((PrvUser)contribution.User).DataId,
                    Amount = contribution.Amount,
                    ExpenseId = this.dataItem.Id.Value,
                };

                this.services
                    .Contributions
                    .set(contributionData);
            }
        }

        public IEnumerable<IContribution> Contributions => this.services
            .Contributions
            .getByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ContributionData, PrvContribution>);

        public IEnumerable<IUser> Debtors => this.services
            .Debtors
            .getDebtorUsersByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<UserData, PrvUser>);

        public string Concept
        {
            get => this.dataItem.Concept;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.Expense_concept_cannot_be_empty);
                this.dataItem.Concept = value;

                this.services
                    .Expenses
                    .set(this.dataItem);
            }
        }

        public DateTime Date => this.dataItem.Date;

        public IEnumerable<ITag> Tags => this.services
            .TaggedExpenses
            .getTagsByExpense(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<TagData, PrvTag>);

        public int Id => this.dataItem.Id.Value;

        public void setDebtor(IUser user)
        {
            bool userIsAlreadyDebtor;
            int userId;

            this.services.Asserts.isInstanceOf<PrvUser>(user);

            userId = (user as PrvUser).DataId;

            userIsAlreadyDebtor = this.services
                .Debtors
                .getDebtorUsersByExpense(this.DataId)
                .Any(u => u.Id == userId);

            this.services.Validator.isFalse(userIsAlreadyDebtor
                , this.services.Strings.User_is_already_a_debtor_of_expense(user.Name, this.DataId));

            this.services
                .Debtors
                .set(new DebtorData
                {
                    ExpenseId = this.dataItem.Id.Value,
                    UserId = userId,
                });
        }

        public void setTag(ITag tag)
        {
            this.services.Asserts.isInstanceOf<PrvTag>(tag);

            this.services
                .TaggedExpenses
                .set(new TaggedExpenseData
                {
                    ExpenseId = this.dataItem.Id.Value,
                    TagId = (tag as PrvTag).DataId,
                });
        }

        protected override void prv_validate(ExpenseData data)
        {
            this.services.Validator.stringIsNotEmpty(data.Concept, this.services.Strings.Expense_concept_cannot_be_empty);
            this.services.Validator.date_must_be_after_year_1900(data.Date);
        }

        private static ExpenseData prv_buildData(IExpenseRepository repository, DateTime date, string concept)
        {
            ExpenseData expenseData;

            expenseData = new ExpenseData
            {
                Date = date,
                Concept = concept,
            };

            repository.set(expenseData);
            return expenseData;
        }
    }
}
