using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Domain.Models.Internals
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

        public IUser User
        {
            get
            {
                IUser user;
                UserData userData;

                userData = this.repository.getSingleUser(this.dataItem.UserId);
                user = prv_createDomainInstance<UserData, User>(userData);

                return user;
            }
        }

        public decimal Amount => this.dataItem.Amount;
        public IExpense Expense => this.parentExpense;

        protected override void prv_validate(ContributionData data)
        {
            this.assert.isNotNull(data);
            this.validate.isTrue(data.Amount > 0, "Amount must be positive");
        }
    }
}
