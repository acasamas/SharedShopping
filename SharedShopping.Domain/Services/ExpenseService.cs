using System;
using System.Collections.Generic;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class ExpenseService : AbstractService, IExpenseService
    {
        public ExpenseService() : base()
        {

        }

        public IEnumerable<Debt> getCurrentDebtBalance()
        {
            return base.prv_computeDebtBalance();
        }
    }
}