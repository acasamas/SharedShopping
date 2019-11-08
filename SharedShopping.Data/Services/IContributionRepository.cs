using SharedShopping.Data.Models;
using System.Collections.Generic;

namespace SharedShopping.Data.Services
{
    public interface IContributionRepository : IAdditiveRepository<ContributionData>
    {
        IEnumerable<ContributionData> getByExpense(int expenseId);
        IEnumerable<ContributionData> getByUser(int userId);
    }
}