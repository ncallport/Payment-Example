
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class ErrorDetailModel
    {

        //{
        // "code":2,
        // "fieldName":"JudoId",
        // "message":"Sorry, but it looks like the judo ID supplied is invalid. Please check your details and try again.",
        // "detail":"Sorry, we're currently unable to process this request."
        //}

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

    }
}
