using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class Contribution : AbstractDomainModel<ContributionData>, IContribution
    {
        private readonly Expense parentExpense;

        public Contribution(IDomainCore domainCore
            , ContributionData dataItem, Expense parentExpense)
            : base(domainCore, dataItem)
        {
            this.parentExpense = parentExpense;
        }

        public IUser User => this.domainCore
            .Repository
            .getSingleUser(this.dataItem.UserId)
            .mapTo(prv_createDomainInstance<UserData, User>);

        public decimal Amount => this.dataItem.Amount;
        public IExpense Expense => this.parentExpense;

        protected override void prv_validate(ContributionData data)
        {
            this.domainCore.contribution_amount_is_positive(data.Amount);
        }
    }
}
