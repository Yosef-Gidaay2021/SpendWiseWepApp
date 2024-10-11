namespace spendwisebase.Models ;
public class ExpenseCategory
{
    public int ExpenseCategoryId { get; set; }
    public string? Name { get; set; } // e.g., "Food", "Transport", "Shopping", etc.

    // Navigation property to track related transactions
  //  public List<Transaction> Transactions { get; set; }
 }
