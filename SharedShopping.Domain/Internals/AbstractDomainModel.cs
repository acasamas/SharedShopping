using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal abstract class AbstractDomainModel<TData> : AbstractService where TData: class
    {
        protected TData dataItem;

        public AbstractDomainModel(IValidator validate, IRepository repository) 
            : base(validate, repository)
        {
            this.dataItem = null;
        }

        protected AbstractDomainModel(IValidator validate, IRepository repository, TData dataItem)
            : this(validate, repository)
        {
            prv_validate(dataItem);
            this.dataItem = dataItem;
        }

        protected abstract void prv_validate(TData data);
    }
}
