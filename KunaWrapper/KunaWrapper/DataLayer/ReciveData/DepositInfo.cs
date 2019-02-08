using Newtonsoft.Json;
using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class DepositInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("currency")]
        public string CurrencyId { get; private set; }

        private readonly decimal amount;
        public decimal Amount => amount;

        private readonly decimal fee;
        public decimal Fee => fee;

        [JsonProperty("created_at")]
        public string CreatedTime { get; private set; }

        [JsonProperty("state")]
        public string State { get; private set; }

        [JsonProperty("payment_address_id")]
        public string OutId { get; private set; }


        [JsonConstructor]
        public DepositInfo(string amount, string fee)
        {
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
            decimal.TryParse(fee, Any, InvariantCulture, out this.fee);
        }
    }
}
