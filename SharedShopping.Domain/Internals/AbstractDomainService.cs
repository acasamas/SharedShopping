using System;
using System.Collections.Generic;
using Blacksmith.Validations;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal abstract class AbstractDomainService<TData> : AbstractService where TData: class
    {
        protected TData dataItem;

         protected AbstractDomainService(IDomainServices services, TData dataItem)
            : base(services)
        {
            this.services.Asserts.isNotNull(dataItem);
            prv_validate(dataItem);
            this.dataItem = dataItem;
        }

        protected abstract void prv_validate(TData data);

    }
}
