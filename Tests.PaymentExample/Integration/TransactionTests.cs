using System.Linq;
using NUnit.Framework;
using Services.PaymentExample.Services;

namespace Tests.PaymentExample.Integration
{
    [TestFixture]
    public class TransactionTests : TestBase
    {

        private readonly TransactionService _transactionService;

        public TransactionTests()
        {
            _transactionService = new TransactionService();
        }

        [Test]
        public void SuccessfulTransactionTest()
        {
            // GIVEN A VALID TEST CARD NUMBER THAT RETURNS SUCCESSFUL
            var cardNumber = "4976000000003436";
            // AND VALID EXPIRY DATE
            var expiryDate = "12/20";
            // AND VALID CV2
            var cv2 = "452";
            // AND VALID AMOUNT
            var amount = 1.01m;

            // WHEN A TRANSACTION IS ATTEMPTED
            var transactionResponse = _transactionService.FullCardPayment(cardNumber, expiryDate, cv2, amount);

            // THEN NO ERROR SHOULD BE RETURNED
            Assert.False(transactionResponse.HasError);

            // AND THE TRANSACTION SHOULD BE SUCCESSFUL
            Assert.AreEqual(transactionResponse.Receipt.Result, "Success");
        }

        [Test]
        public void DeclinedTransactionTest()
        {
            // GIVEN A VALID TEST CARD NUMBER THAT RETURNS DECLINED
            var cardNumber = "4221690000004963";
            // AND VALID EXPIRY DATE
            var expiryDate = "12/20";
            // AND VALID CV2
            var cv2 = "125";
            // AND VALID AMOUNT
            var amount = 1.01m;

            // WHEN A TRANSACTION IS ATTEMPTED
            var transactionResponse = _transactionService.FullCardPayment(cardNumber, expiryDate, cv2, amount);

            // THEN NO ERROR SHOULD BE RETURNED
            Assert.False(transactionResponse.HasError);

            // AND THE TRANSACTION SHOULD BE DECLINED
            Assert.AreEqual(transactionResponse.Receipt.Result, "Declined");
        }

        [Test]
        public void TransactionWithNonTestCardTest()
        {
            // GIVEN A VALID TEST CARD NUMBER THAT RETURNS DECLINED
            var cardNumber = "4462000000000003";
            // AND VALID EXPIRY DATE
            var expiryDate = "12/20";
            // AND VALID CV2
            var cv2 = "125";
            // AND VALID AMOUNT
            var amount = 1.01m;

            // WHEN A TRANSACTION IS ATTEMPTED
            var transactionResponse = _transactionService.FullCardPayment(cardNumber, expiryDate, cv2, amount);

            // THEN HASERROR SHOULD BE TRUE
            Assert.True(transactionResponse.HasError);

            // AND THE TRANSACTION SHOULD BE SUCCESSFUL
            Assert.AreEqual(transactionResponse.Error.Details.First().Message, "Sorry, it looks like you're using a live card in the sandbox environment. Live Cards are only for use in the production environment.");
        }

        [Test]
        public void TransactionWithInvalidCardNumberTest()
        {
            // GIVEN A VALID TEST CARD NUMBER THAT RETURNS DECLINED
            var cardNumber = "4444000044440000";
            // AND VALID EXPIRY DATE
            var expiryDate = "12/20";
            // AND VALID CV2
            var cv2 = "125";
            // AND VALID AMOUNT
            var amount = 1.01m;

            // WHEN A TRANSACTION IS ATTEMPTED
            var transactionResponse = _transactionService.FullCardPayment(cardNumber, expiryDate, cv2, amount);

            // THEN HASERROR SHOULD BE TRUE
            Assert.True(transactionResponse.HasError);

            // AND THE TRANSACTION SHOULD BE SUCCESSFUL
            Assert.AreEqual(transactionResponse.Error.Details.First().Message, "Sorry, it looks like the card number entered is invalid. Please check your details and try again.");
        }


    }
}
