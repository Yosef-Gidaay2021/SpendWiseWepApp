using Xunit;
using Moq;
using spendwisebase.Models;
using SpendWiseWebApp.Services;
using MSTestAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class ReceiptServiceTests
{
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
}