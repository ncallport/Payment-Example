
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class ConsumerModel
    {

        //    "consumer": {
        //      "consumerToken": "xgc6miEXXReifcdn",
        //      "yourConsumerReference": "consumer1234567"
        //    }

        [JsonProperty("consumerToken")]
        public string ConsumerToken { get; set; }

        [JsonProperty("yourConsumerReference")]
        public string YourConsumerReference { get; set; }

    }
}
