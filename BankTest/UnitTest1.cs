using BankAccountNS;
using Moq;

// The 'using' statement for Test Tools is in GlobalUsings.cs
// using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        //Using Moq
        [TestMethod]
        public void Debit_WithInvalidAmount_ThrowsException()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 12.00;

            var mockAcct = new Mock<BankAccount>("Mr. Bryan Walton", beginningBalance);

            // Act/Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mockAcct.Object.Debit(debitAmount));

        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            //Arrange
            double startBal = 11.99;
            double depoAmt = 100.00;
            var mockAcct = new Mock<BankAccount>("Mr. Bryan Walton", startBal);

            //Act
            mockAcct.Object.Credit(depoAmt);

            //Assert
            Assert.AreEqual(startBal + depoAmt, mockAcct.Object.Balance);

        }
    }
}