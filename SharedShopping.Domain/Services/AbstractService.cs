using System;
using System.Collections.Generic;
using SharedShopping.Data.Models;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public abstract class AbstractService : AbstractAppDomain
    {
        protected IEnumerable<Debt> prv_computeDebtBalance()
        {
            throw new NotImplementedException();
        }

        protected static Tag map(TagData data)
        {
            return new Tag(data.Name);
        }

        protected static User map(UserData data)
        {
            return new User(data.Name);
        }

    }
}
