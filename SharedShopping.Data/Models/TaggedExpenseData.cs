namespace SharedShopping.Data.Models
{
    public class TaggedExpenseData : AbstractData
    {
        public int TagId { get; set; }
        public int ExpenseId { get; set; }
    }
}