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

        public Receipt( string imagePath, int transactionId, string uploadedBy)
        {
            
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException("ImagePath cannot be null or empty.", nameof(imagePath));
            if (transactionId <= 0)
                throw new ArgumentException("TransactionId must be greater than zero.", nameof(transactionId));
            if (string.IsNullOrWhiteSpace(uploadedBy))
                throw new ArgumentException("UploadedBy cannot be null or empty.", nameof(uploadedBy));

            ImagePath = imagePath;
            TransactionId = transactionId;
            UploadedBy = uploadedBy;
        }
    }

}