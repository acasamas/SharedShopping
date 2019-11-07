using System;
using System.Reflection;

namespace SharedShopping.Domain.Services
{
    public abstract class AbstractService
    {
        protected readonly IDomainServices services;

        public AbstractService(IDomainServices services)
        {
            this.services = services;
        }

        protected TOut prv_createDomainInstance<TIn, TOut>(TIn source)
        {
            Type outType;
            ConstructorInfo constructor;

            outType = typeof(TOut);
            constructor = outType.GetConstructor(new Type[] { typeof(IDomainServices), typeof(TIn) });
            this.services.Asserts.isNotNull(constructor);

            return (TOut)constructor.Invoke(new object[] { this.services, source });
        }
    }
}
