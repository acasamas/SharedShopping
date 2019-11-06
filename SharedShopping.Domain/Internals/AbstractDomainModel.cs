using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal abstract class AbstractDomainModel<TData> : AbstractService where TData: class
    {
        protected TData dataItem;

         protected AbstractDomainModel(IDomainCore domainCore, TData dataItem)
            : base(domainCore)
        {
            this.domainCore.Assert.isNotNull(dataItem);
            prv_validate(dataItem);
            this.dataItem = dataItem;
        }

        protected abstract void prv_validate(TData data);
    }
}
