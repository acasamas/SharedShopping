using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharedShopping.Domain.Models.Internals
{
    internal abstract class AbstractDomainModel<TData> where TData: class
    {
        protected readonly Asserts assert;
        protected TData dataItem;
        protected readonly IValidator validate;
        protected readonly IRepository repository;

        public AbstractDomainModel(IValidator validate, IRepository repository)
        {
            this.assert = Asserts.Assert;

            this.assert.isNotNull(validate);
            this.assert.isNotNull(repository);

            this.validate = validate;
            this.repository = repository;
            this.dataItem = null;
        }

        protected AbstractDomainModel(IValidator validate, IRepository repository, TData dataItem)
            : this(validate, repository)
        {
            prv_validate(dataItem);
            this.dataItem = dataItem;
        }

        protected abstract void prv_validate(TData data);

        protected TOut prv_createDomainInstance<TIn, TOut>(TIn source)
        {
            Type outType;
            ConstructorInfo constructor;

            outType = typeof(TOut);
            constructor = outType.GetConstructor(new Type[] { typeof(IValidator), typeof(IRepository), typeof(TIn) });
            this.assert.isNotNull(constructor);

            return (TOut)constructor.Invoke(new object[] { this.validate, this.repository, source });
        }
    }
}
