using SharedShopping.Domain.Models;
using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface IExpenseService
    {
        IExpense createExpense(DateTime date, string concept
            , IEnumerable<UserContribution> contributions);

        IEnumerable<Debt> getCurrentDebtBalance();
    }
}
