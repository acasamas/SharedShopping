using System;

namespace SharedShopping.Data.Models
{
    public class ExpenseData : AbstractData
    {
        public DateTime Date { get; set; }
        public string Concept { get; set; }
    }
}