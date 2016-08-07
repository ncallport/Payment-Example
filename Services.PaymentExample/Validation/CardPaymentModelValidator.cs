using System;
using System.Linq;
using FluentValidation;
using Models.PaymentExample.Models;

namespace Services.PaymentExample.Validation
{
    public class CardPaymentModelValidator : AbstractValidator<CardPaymentModel>
    {

        public CardPaymentModelValidator()
        {
            RuleFor(card => card.CardNumber)
                .Must(IsNumeric)
                .Length(16)
                .WithMessage("Please enter a 16 digit Card Number");

            RuleFor(card => card.ExpiryDate)
                .Must(IsValidExpiry)
                .WithMessage("Please enter a valid Expiry Date (MM/YY)");

            RuleFor(card => card.CV2).Must(IsNumeric).Length(3).WithMessage("Please enter a 3 digit CV2");

            RuleFor(card => card.Amount).GreaterThan(0).WithMessage("Please enter an amount greater than zero");
        }
        
        private bool IsNumeric(string check)
        {
            return check.All(c => c >= '0' && c <= '9');
        }

        private bool IsValidExpiry(string check)
        {
            if (check.Length < 5 || check.Length > 5)
                return false;

            var monthString = check.Split('/')[0];
            var yearString = check.Split('/')[1];

            int month;
            int year;

            if (!int.TryParse(monthString, out month))
                return false;

            if (!int.TryParse(yearString, out year))
                return false;

            if (month < 1 || month > 12)
                return false;

            yearString = "20" + yearString;
            year = int.Parse(yearString);
            return year >= DateTime.Now.Year;
        }

    }
}
