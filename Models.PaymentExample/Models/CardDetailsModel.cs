
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class CardDetailsModel
    {

        //    "cardDetails": {
        //      "cardLastfour": "3436",
        //      "endDate": "1220",
        //      "cardToken": "wO4hborwsiirCXsbDmAKmdFQBdXPeYmu",
        //      "cardType": 1
        //    }

        [JsonProperty("cardLastfour")]
        public string CardLastFour { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("cardToken")]
        public string CardToken { get; set; }

        [JsonProperty("cardType")]
        public int CardType { get; set; }
    }
}
