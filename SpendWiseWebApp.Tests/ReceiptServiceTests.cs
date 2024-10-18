using Xunit;
using Moq;
using spendwisebase.Models;
using SpendWiseWebApp.Services;
using MSTestAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWiseWebApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

public class ReceiptServiceTests
{
    private readonly SpendWiseContext _context;
    private readonly ReceiptService _receiptService;

    public ReceiptServiceTests()
    {
        var options = new DbContextOptionsBuilder<SpendWiseContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new SpendWiseContext(options);
        _receiptService = new ReceiptService(_context);
    }

    [Fact]
    public void TestMethod1()
    {
        // Test code here
        MSTestAssert.IsTrue(true); // Use alias for MSTest Assert
    }

    [Fact]
    public void TestReceiptConstructor()
    {
        var receipt = new Receipt("Test", 123, "imagePath");
        MSTestAssert.IsNotNull(receipt);
    }

    [Fact]
    public async Task UploadReceiptAsync_AddsReceipt()
    {
        var fileMock = new Mock<IFormFile>();
        var content = "Hello World from a Fake File";
        var fileName = "test.txt";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);

        var receiptDto = new ReceiptUploadDto
        {
            File = fileMock.Object,
            TransactionId = 1,
            UploadedBy = "user"
        };

        // Ensure the directory exists
        var directoryPath = Path.Combine("uploads");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var result = await _receiptService.UploadReceiptAsync(receiptDto);
        MSTestAssert.IsNotNull(result);
    }

    [Fact]
    public async Task DeleteReceiptAsync_DeletesReceipt()
    {
        var receipt = new Receipt("path", 1, "user");

        _context.Receipts.Add(receipt);
        await _context.SaveChangesAsync();

        var result = await _receiptService.DeleteReceiptAsync(1);
        MSTestAssert.IsTrue(result);
    }
}