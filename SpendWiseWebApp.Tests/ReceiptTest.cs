
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spendwisebase.Models;


namespace SpendWiseWebApp.Tests;

    [TestClass]
    public class ReceiptTest
    {
        [TestMethod]
        public void Receipt_ValidParameters_ShouldInstantiate()
        {
            // Arrange
            string imagePath = "img/image.jpg";
            int transactionId = 1;
            string uploadedBy = "param";
    
            // Act
            var receipt = new Receipt(imagePath, transactionId, uploadedBy);
    
            // Assert
            Assert.AreEqual(imagePath, receipt.ImagePath);
            Assert.AreEqual(transactionId, receipt.TransactionId);
            Assert.AreEqual(uploadedBy, receipt.UploadedBy);
        }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Receipt_NullOrEmptyImagePath_ShouldThrowException()
        {
            // Arrange
            string imagePath = "";
            int transactionId = 1;
            string uploadedBy = "param";
    
            try
            {
                // Act
                var receipt = new Receipt(imagePath, transactionId, uploadedBy);
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("ImagePath cannot be null or empty. (Parameter 'imagePath')", ex.Message);
                throw;
            }
        }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Receipt_TransactionIdLessThanOrEqualToZero_ShouldThrowException()
        {
            // Arrange
            string imagePath = "img/image.jpg";
            int transactionId = 0;
            string uploadedBy = "param";
    
            try
            {
                // Act
                var receipt = new Receipt(imagePath, transactionId, uploadedBy);
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("TransactionId must be greater than zero. (Parameter 'transactionId')", ex.Message);
                throw;
            }
        }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Receipt_NullOrEmptyUploadedBy_ShouldThrowException()
        {
            // Arrange
            string imagePath = "img/image.jpg";
            int transactionId = 1;
            string uploadedBy = "";
    
            try
            {
                // Act
                var receipt = new Receipt(imagePath, transactionId, uploadedBy);
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("UploadedBy cannot be null or empty. (Parameter 'uploadedBy')", ex.Message);
                throw;
            }
        }
    
        [TestMethod]
        public void Receipt_SetTransaction_ShouldUpdateTransaction()
        {
            // Arrange
            string imagePath = "img/image.jpg";
            int transactionId = 1;
            string uploadedBy = "param";
            var receipt = new Receipt(imagePath, transactionId, uploadedBy);
            var transaction = new Transaction { TransactionId = transactionId };
    
            // Act
            receipt.Transaction = transaction;
    
            // Assert
            Assert.AreEqual(transaction, receipt.Transaction);
        }
    }
