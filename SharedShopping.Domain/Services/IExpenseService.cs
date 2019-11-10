using SharedShopping.Domain.Models;
using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface IExpenseService
    {
        IEnumerable<Debt> getCurrentDebtBalance();
    }
}
