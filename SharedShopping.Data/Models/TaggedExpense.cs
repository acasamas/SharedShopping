namespace SharedShopping.Data.Models
{
    public class TaggedExpense : AbstractData
    {
        public int TagId { get; set; }
        public int ExpenseId { get; set; }
    }
}