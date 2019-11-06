using Blacksmith.Validations;
using SharedShopping.Data.Services;
using System;
using System.Reflection;

namespace SharedShopping.Domain.Services
{
    public abstract class AbstractService
    {
        protected readonly IDomainCore domainCore;

        public AbstractService(IDomainCore domainCore)
        {
            this.domainCore = domainCore;
        }

        protected TOut prv_createDomainInstance<TIn, TOut>(TIn source)
        {
            Type outType;
            ConstructorInfo constructor;

            outType = typeof(TOut);
            constructor = outType.GetConstructor(new Type[] { typeof(IDomainCore), typeof(TIn) });
            this.domainCore.Assert.isNotNull(constructor);

            return (TOut)constructor.Invoke(new object[] { this.domainCore, source });
        }
    }
}
