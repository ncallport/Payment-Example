using Models.PaymentExample.Models;
using NUnit.Framework;
using Services.PaymentExample.Validation;

namespace Tests.PaymentExample.Validation
{
    [TestFixture]
    public class CardPaymentModelTests
    {

        [Test]
        [TestCase("111111")] // TOO SHORT
        [TestCase("8768uyguygi9][]jh")] // MUST BE NUMERIC ONLY
        [TestCase("98798799879879797979879879879879")] // TOO LONG
        public void FailCardNumberTest(string cardNumber)
        {
            var cardPayment = GetCardPaymentModel(cardNumber);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.False(validationResult.IsValid);
        }

        [Test]
        [TestCase("1111222233334444")] // FAKE NUMBER SHOULD PASS
        [TestCase("4976000000003436")] // REAL NUMBER SHOULD PASS
        public void PassCardNumberTest(string cardNumber)
        {
            var cardPayment = GetCardPaymentModel(cardNumber);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.True(validationResult.IsValid);
        }

        [Test]
        [TestCase("1220")] // TOO SHORT
        [TestCase("98798797")] // TOO LONG
        [TestCase("89/90")] // INVALID MONTH AND YEAR
        [TestCase("99/20")] // INVALID MONTH
        [TestCase("12/15")] // INVALID YEAR
        public void FailExpiryDateTest(string expiryDate)
        {
            var cardPayment = GetCardPaymentModel(expiryDate: expiryDate);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.False(validationResult.IsValid);
        }

        [Test]
        [TestCase("12/20")]
        public void PassExpiryDateTest(string expiryDate)
        {
            var cardPayment = GetCardPaymentModel(expiryDate: expiryDate);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.True(validationResult.IsValid);
        }

        [Test]
        [TestCase("5")] // TOO SHORT
        [TestCase("13244")] // TOO LONG
        [TestCase("T44")] // MUST BE NUMERIC
        public void FailCV2Test(string cv2)
        {
            var cardPayment = GetCardPaymentModel(cv2: cv2);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.False(validationResult.IsValid);
        }

        [Test]
        [TestCase("452")]
        public void PassCV2Test(string cv2)
        {
            var cardPayment = GetCardPaymentModel(cv2: cv2);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.True(validationResult.IsValid);
        }

        [Test]
        [TestCase(0)] // MUST BE GREATER THAN 0
        [TestCase(-2)] // MUST BE GREATER THEN 0
        public void FailAmountTest(decimal amount)
        {
            var cardPayment = GetCardPaymentModel(amount: amount);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.False(validationResult.IsValid);
        }

        [Test]
        [TestCase(0.55)]
        [TestCase(10.01)]
        public void PassAmountTest(decimal amount)
        {
            var cardPayment = GetCardPaymentModel(amount: amount);
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            Assert.True(validationResult.IsValid);
        }

        private CardPaymentModel GetCardPaymentModel(string cardNumber = "4976000000003436", string expiryDate = "12/20", string cv2 = "452",
            decimal amount = 1.01m)
        {
            return new CardPaymentModel
            {
                CardNumber = cardNumber,
                ExpiryDate = expiryDate,
                CV2 = cv2,
                Amount = amount
            };
        }

    }
    
}
