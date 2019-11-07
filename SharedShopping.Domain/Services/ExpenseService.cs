using System;
using System.Collections.Generic;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class ExpenseService : AbstractService, IExpenseService
    {
        public ExpenseService(IDomainServices services) : base(services)
        {

        }

        public IExpense createExpense(DateTime date, string concept, IEnumerable<UserContribution> contributions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Debt> getCurrentDebtBalance()
        {
            return base.prv_computeDebtBalance();
        }
    }
}