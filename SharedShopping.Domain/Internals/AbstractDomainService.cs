using SharedShopping.Data.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal abstract class AbstractDomainService<TData> : AbstractService where TData : AbstractData
    {
        protected readonly TData dataItem;

        protected AbstractDomainService(IDomainServices services, TData dataItem) : base(services)
        {
            this.services.Asserts.isNotNull(dataItem);
            prv_validate(dataItem);
            this.dataItem = dataItem;
        }

        public int DataId => this.dataItem.Id.Value;

        protected abstract void prv_validate(TData data);

    }
}
