using System;

namespace SharedShopping.Data.Models
{
    public class ContributionData : AbstractData
    {
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int ExpenseId { get; set; }
    }
}