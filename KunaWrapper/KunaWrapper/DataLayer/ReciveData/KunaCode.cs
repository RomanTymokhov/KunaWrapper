using Newtonsoft.Json;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class KunaCode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string CodeString { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("non_refundable_before")]
        public string NonRefundableBefore { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("private_comment")]
        public string PrivateComment { get; set; }
    }
}
