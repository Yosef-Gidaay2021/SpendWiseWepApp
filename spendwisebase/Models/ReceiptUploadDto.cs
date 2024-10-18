using Microsoft.AspNetCore.Http;

namespace spendwisebase.Models
{
    public class ReceiptUploadDto
    {
        public IFormFile File { get; set; }
        public string UploadedBy { get; set; }
       public int TransactionId { get; set; }
    }
}