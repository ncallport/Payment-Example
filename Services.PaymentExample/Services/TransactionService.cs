using System;
using System.Configuration;
using System.Net;
using Models.PaymentExample.Models;
using Newtonsoft.Json;
using Services.PaymentExample.Interfaces;
using Services.PaymentExample.Validation;

namespace Services.PaymentExample.Services
{
    public class TransactionService : ServiceBase, ITransactionService
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _judoId = ConfigurationManager.AppSettings["JudoId"];
        private readonly string _apiToken = ConfigurationManager.AppSettings["ApiToken"];
        private readonly string _apiSecret = ConfigurationManager.AppSettings["ApiSecret"];
        private readonly string _apiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        private readonly string _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string _currency = ConfigurationManager.AppSettings["Currency"];

        public TransactionResponseModel FullCardPayment(string cardNumber, string expiryDate, string cv2, decimal amount)
        {
            // SET UP RESPONSE MODELS
            ReceiptModel receipt = null;
            ErrorModel error = null;

            // CREATE CARD PAYMENT MODEL
            var cardPayment = ReturnCardPaymentModel(_judoId, cardNumber, expiryDate, cv2, amount, _currency);

            // VALIDATE CARD PAYMENT MODEL
            var validator = new CardPaymentModelValidator();
            var validationResult = validator.Validate(cardPayment);
            
            // IF VALIDATION FAILS, RETURN AN ERROR
            if (!validationResult.IsValid)
            {
                error = new ErrorModel();
                var failures = validationResult.Errors;
                string message = null;
                foreach (var failure in failures)
                {
                    message += failure.ErrorMessage + "\n";
                }
                error.Message = message;

                Log.Info($"Transaction validation failed with errors: {message}");

                return new TransactionResponseModel
                {
                    Error = error,
                    HasError = true
                };
            }

            try
            {

                // VALIDATION OKAY, PROCESS TRANSACTION
                var jsonRequest = JsonConvert.SerializeObject(cardPayment);
                var authorisation = ReturnAuthorisation(_apiToken, _apiSecret);
                var baseUrl = $"{_baseUrl}transactions/payments";
                var response = DoRestRequest(baseUrl, _apiVersion, authorisation, jsonRequest);
                var hasError = false;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        Log.Info($"Transaction returned with response: {response.Content}");
                        receipt = JsonConvert.DeserializeObject<ReceiptModel>(response.Content);
                        break;
                    default:
                        hasError = true;
                        Log.Info($"Transaction failed from Judo with message: {response.Content}");
                        error = JsonConvert.DeserializeObject<ErrorModel>(response.Content);
                        break;
                }

                return new TransactionResponseModel
                {
                    Receipt = receipt,
                    Error = error,
                    HasError = hasError
                };

            }
            catch (Exception ex)
            {
                // LOG ERROR
                Log.Info($"Transaction failed from Judo with exception: {ex}");

                // RETURN RESPONSE WITH ERROR MESSAGE
                error = new ErrorModel {Message = ex.Message};
                return new TransactionResponseModel
                {
                    Receipt = null,
                    Error = error,
                    HasError = true
                };
            }

        }
    }
}
