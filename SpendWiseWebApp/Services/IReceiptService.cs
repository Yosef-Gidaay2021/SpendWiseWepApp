using spendwisebase.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWiseWebApp.Services
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> GetAllReceiptsAsync();
        Task<Receipt> GetReceiptByIdAsync(int id);
        Task<Receipt> UploadReceiptAsync(ReceiptUploadDto receiptDto);
        Task<bool> DeleteReceiptAsync(int id);
    }
}
