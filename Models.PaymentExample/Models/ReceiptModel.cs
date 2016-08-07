using System;
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class ReceiptModel
    {

        //{
        //    "receiptId": "5059985",
        //    "yourPaymentReference": "payment123456",
        //    "type": "Payment",
        //    "createdAt": "2016-08-06T14:59:53.3662+01:00",
        //    "result": "Success",
        //    "message": "AuthCode: 857810",
        //    "judoId": 100307149,
        //    "merchantName": "Nick Allport",
        //    "appearsOnStatementAs": "APL/NickAllp",
        //    "originalAmount": "1.01",
        //    "netAmount": "1.01",
        //    "amount": "1.01",
        //    "currency": "GBP",
        //    "cardDetails": {
        //      "cardLastfour": "3436",
        //      "endDate": "1220",
        //      "cardToken": "wO4hborwsiirCXsbDmAKmdFQBdXPeYmu",
        //      "cardType": 1
        //    },
        //    "consumer": {
        //      "consumerToken": "xgc6miEXXReifcdn",
        //      "yourConsumerReference": "consumer1234567"
        //    },
        //    "risks": {
        //      "postCodeCheck": "UNKNOWN"
        //    }
        //}

        [JsonProperty("receiptId")]
        public string ReceiptId { get; set; }

        [JsonProperty("yourPaymentReference")]
        public string YourPaymentReference { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("judoId")]
        public string JudoId { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("appearsOnStatementAs")]
        public string AppearsOnStatementAs { get; set; }

        [JsonProperty("originalAmount")]
        public decimal OriginalAmount { get; set; }

        [JsonProperty("netAmount")]
        public decimal NetAmount { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cardDetails")]
        public CardDetailsModel CardDetails { get; set; }

        [JsonProperty("consumer")]
        public ConsumerModel Consumer { get; set; }

        [JsonProperty("risks")]
        public RisksModel Risks { get; set; }

    }
}
