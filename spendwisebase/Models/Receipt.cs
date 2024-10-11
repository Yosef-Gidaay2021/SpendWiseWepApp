namespace spendwisebase.Models;
public class Receipt
{
    public int ReceiptId { get; set; }
    public string ImagePath { get; set; } // Path to stored receipt image
    public int TransactionId { get; set; } // Foreign Key to Transaction

    // Navigation property for Transaction
    public Transaction Transaction { get; set; }
}