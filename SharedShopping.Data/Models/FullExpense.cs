using System.Collections.Generic;

namespace SharedShopping.Data.Models
{
    public class FullExpense
    {
        public ExpenseData Expense { get; set; }
        public IEnumerable<UserData> Debtors { get; set; }
        public IEnumerable<ExpenseContribution> Contributions { get; set; }
        public IEnumerable<TagData> Tags { get; set; }
    }
}