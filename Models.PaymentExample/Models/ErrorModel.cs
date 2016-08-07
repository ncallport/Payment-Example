
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.PaymentExample.Models
{
    public class ErrorModel
    {

        //{
        // "details":[{"code":2,"fieldName":"JudoId","message":"Sorry, but it looks like the judo ID supplied is invalid. Please check your details and try again.","detail":"Sorry, we're currently unable to process this request."}],
        // "message":"Sorry, we're unable to process your request. Please check your details and try again.",
        // "code":1,
        // "category":2
        //}

        [JsonProperty("details")]
        public List<ErrorDetailModel> Details { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

    }
}
