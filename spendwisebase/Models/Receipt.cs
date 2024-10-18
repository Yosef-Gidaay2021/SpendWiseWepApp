namespace spendwisebase.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public string ImagePath { get; set; } // Path to stored receipt image
        public int TransactionId { get; set; } // Foreign Key to Transaction
        public string UploadedBy { get; set; } // User who uploaded the receipt

        // Navigation property for Transaction
        public Transaction Transaction { get; set; }
    }
}