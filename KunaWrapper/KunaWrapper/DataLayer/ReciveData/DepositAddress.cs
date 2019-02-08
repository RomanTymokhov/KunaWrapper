using Newtonsoft.Json;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class DepositAddress
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; private set; }
    }

    public class  PaymentDetails
    {
        [JsonProperty("address")]
        public string Address { get; private set; }
    }
}
