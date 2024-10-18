using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;
using SpendWiseWebApp.Data;
using SpendWiseWebApp.Services;

namespace SpendWiseWebApp.Tests.Services
{
    public class ReceiptServiceTests
    {
        private readonly Mock<SpendWiseContext> _mockContext;
        private readonly ReceiptService _receiptService;

        public ReceiptServiceTests()
        {
            // Set up a mock DbSet for receipts
            var mockReceipts = new List<Receipt>
            {
                new Receipt { ReceiptId = 1, ImagePath = "path1.jpg", UploadedBy = "user1", TransactionId = 1 },
                new Receipt { ReceiptId = 2, ImagePath = "path2.jpg", UploadedBy = "user2", TransactionId = 2 }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Receipt>>();
            mockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Provider).Returns(mockReceipts.Provider);
            mockDbSet.As<IQueryable<Receipt>>().Setup(m => m.Expression).Returns(mockReceipts.Expression);
            mockDbSet.As<IQueryable<Receipt>>().Setup(m => m.ElementType).Returns(mockReceipts.ElementType);
            mockDbSet.As<IQueryable<Receipt>>().Setup(m => m.GetEnumerator()).Returns(mockReceipts.GetEnumerator());

            // Mock the SpendWiseContext and its Receipts DbSet
            _mockContext = new Mock<SpendWiseContext>();
            _mockContext.Setup(c => c.Receipts).Returns(mockDbSet.Object);

            // Create an instance of the service with the mock context
            _receiptService = new ReceiptService(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllReceiptsAsync_ShouldReturnAllReceipts()
        {
            // Act
            var receipts = await _receiptService.GetAllReceiptsAsync();

            // Assert
            Assert.Equal(2, receipts.Count());
        }

        [Fact]
        public async Task GetReceiptByIdAsync_ValidId_ShouldReturnReceipt()
        {
            // Act
            var receipt = await _receiptService.GetReceiptByIdAsync(1);

            // Assert
            Assert.NotNull(receipt);
            Assert.Equal(1, receipt.ReceiptId);
        }

        [Fact]
        public async Task GetReceiptByIdAsync_InvalidId_ShouldReturnNull()
        {
            // Act
            var receipt = await _receiptService.GetReceiptByIdAsync(99);

            // Assert
            Assert.Null(receipt);
        }

        [Fact]
        public async Task UploadReceiptAsync_ShouldAddReceipt()
        {
            // Arrange
            var receiptDto = new ReceiptUploadDto
            {
                File = null, // Use a real or mocked file in a real scenario
                UploadedBy = "user3",
                TransactionId = 3
            };

            // Act
            var receipt = await _receiptService.UploadReceiptAsync(receiptDto);

            // Assert
            Assert.NotNull(receipt);
            _mockContext.Verify(m => m.Receipts.Add(It.IsAny<Receipt>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task DeleteReceiptAsync_ValidId_ShouldReturnTrue()
        {
            // Arrange
            _mockContext.Setup(m => m.Receipts.FindAsync(1))
                .ReturnsAsync(new Receipt { ReceiptId = 1 });

            // Act
            var result = await _receiptService.DeleteReceiptAsync(1);

            // Assert
            Assert.True(result);
            _mockContext.Verify(m => m.Receipts.Remove(It.IsAny<Receipt>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
        
        [Fact]
        public async Task DeleteReceiptAsync_InvalidId_ShouldReturnFalse()
        {
            // Act
            var result = await _receiptService.DeleteReceiptAsync(99);

            // Assert
            Assert.False(result);
            _mockContext.Verify(m => m.Receipts.Remove(It.IsAny<Receipt>()), Times.Never());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never());
        }

    }
}
