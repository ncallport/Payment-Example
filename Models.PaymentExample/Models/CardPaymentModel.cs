
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class CardPaymentModel
    {

        //{
        //    "yourConsumerReference": "consumer1234567",
        //    "yourPaymentReference": "payment123456",
        //    "judoId": "100307149",
        //    "amount": 1.01,
        //    "cardNumber": "4976000000003436",
        //    "expiryDate": "12/20",
        //    "cv2": "452",
        //    "currency": "GBP"
        //}

        [JsonProperty("yourConsumerReference")]
        public string YourConsumerReference { get; set; }

        [JsonProperty("yourPaymentReference")]
        public string YourPaymentReference { get; set; }

        [JsonProperty("judoId")]
        public string JudoId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }

        [JsonProperty("cv2")]
        public string CV2 { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

    }
}
