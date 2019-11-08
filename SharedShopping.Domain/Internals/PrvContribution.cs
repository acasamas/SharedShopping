using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class PrvContribution : PrvAbstractDomainService<ContributionData>, IContribution
    {
        private readonly PrvExpense parentExpense;

        public PrvContribution(IDomainServices services
            , ContributionData dataItem, PrvExpense parentExpense)
            : base(services, dataItem)
        {
            this.parentExpense = parentExpense;
        }

        public IUser User => this.services
            .Users
            .getSingle(this.dataItem.UserId)
            .mapTo(prv_createDomainInstance<UserData, PrvUser>);

        public decimal Amount => this.dataItem.Amount;
        public IExpense Expense => this.parentExpense;

        protected override void prv_validate(ContributionData data)
        {
            this.services.Validator.contribution_amount_is_positive(data.Amount);
        }
    }
}
