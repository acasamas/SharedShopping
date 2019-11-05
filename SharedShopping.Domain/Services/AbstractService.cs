using Blacksmith.Validations;
using SharedShopping.Data.Services;
using System;
using System.Reflection;

namespace SharedShopping.Domain.Services
{
    public abstract class AbstractService
    {
        protected readonly Asserts assert;
        protected readonly IValidator validate;
        protected readonly IRepository repository;

        public AbstractService(IValidator validate, IRepository repository)
        {
            this.assert = Asserts.Assert;

            this.assert.isNotNull(validate);
            this.assert.isNotNull(repository);

            this.validate = validate;
            this.repository = repository;
        }

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
