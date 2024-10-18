using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using spendwisebase.Models;
using SpendWiseWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SpendWiseWebApp.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly SpendWiseContext _context;

        public ReceiptService(SpendWiseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync()
        {
            return await _context.Receipts.Include(r => r.Transaction).ToListAsync();
        }

        public async Task<Receipt> GetReceiptByIdAsync(int id)
        {
            var receipt = await _context.Receipts.Include(r => r.Transaction)
                                                 .FirstOrDefaultAsync(r => r.ReceiptId == id);
            if (receipt == null)
            {
                throw new KeyNotFoundException($"Receipt with ID {id} not found.");
            }
            return receipt;
        }

        public async Task<Receipt> UploadReceiptAsync(ReceiptUploadDto receiptDto)
        {
            // Save the uploaded file to a local path or cloud storage (simplified example)
            var filePath = Path.Combine("uploads", receiptDto.File.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await receiptDto.File.CopyToAsync(stream);
            }

            var receipt = new Receipt(filePath, receiptDto.TransactionId, receiptDto.UploadedBy);
            

            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }

        public async Task<bool> DeleteReceiptAsync(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return false;
            }

            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
