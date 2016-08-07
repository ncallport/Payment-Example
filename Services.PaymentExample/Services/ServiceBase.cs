using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Models.PaymentExample.Models;
using RestSharp;

namespace Services.PaymentExample.Services
{
    public class ServiceBase
    {

        protected string ReturnAuthorisation(string apiToken, string apiSecret)
        {
            var authorisation = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiToken}:{apiSecret}"));
            return $"Basic {authorisation}";
        }

        protected internal CardPaymentModel ReturnCardPaymentModel(string judoId, string cardNumber, string expiryDate, string cv2, decimal amount, string currency)
        {
            return new CardPaymentModel
            {
                YourPaymentReference = Guid.NewGuid().ToString(),
                YourConsumerReference = Guid.NewGuid().ToString(),
                JudoId = judoId,
                CardNumber = cardNumber,
                ExpiryDate = expiryDate,
                CV2 = cv2,
                Amount = amount,
                Currency = currency
            };
        }

        protected IRestResponse DoRestRequest(string baseUrl, string apiVersion, string authorisation, string jsonRequest)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            request.AddHeader("api-version", apiVersion);
            request.AddHeader("authorization", authorisation);
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            return client.Execute(request);
        }

        protected string ValidCardNumberLength(string cardnumber)
        {
            cardnumber = RemoveNonNumeric(cardnumber);
            if (cardnumber.Length < 16 || cardnumber.Length > 16)
                return "Card number must be 16 digits";
            return null;
        }

        protected string RemoveNonNumeric(string checkString)
        {
            var regexObj = new Regex(@"[^\d]");
            return regexObj.Replace(checkString, "");
        }

    }
}
