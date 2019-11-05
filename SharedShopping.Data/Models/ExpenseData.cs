using System;
using System.Collections.Generic;

namespace SharedShopping.Data.Models
{
    public class ExpenseData : AbstractData
    {
        public DateTime Date { get; set; }
        public string Concept { get; set; }
    }
}