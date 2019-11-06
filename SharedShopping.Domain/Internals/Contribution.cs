using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Internals
{
    internal class Contribution : AbstractDomainModel<ContributionData>, IContribution
    {
        private readonly Expense parentExpense;

        public Contribution(IValidator validate, IRepository repository
            , ContributionData dataItem, Expense parentExpense)
            : base(validate, repository, dataItem)
        {
            this.parentExpense = parentExpense;
        }

        public IUser User => this.repository
                    .getSingleUser(this.dataItem.UserId)
                    .mapTo(prv_createDomainInstance<UserData, User>);

        public decimal Amount => this.dataItem.Amount;
        public IExpense Expense => this.parentExpense;

        protected override void prv_validate(ContributionData data)
        {
            this.validate.isTrue(data.Amount > 0, "Amount must be positive");
        }
    }
}
