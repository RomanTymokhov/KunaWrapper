using Newtonsoft.Json;

namespace CunaWrapper.DataLevel.RciveData
{
    public class TickerLine
    {
        [JsonProperty(PropertyName = "at")]
        public int at;

        [JsonProperty(PropertyName = "ticker")]
        public Ticker ticker;
    }

    public class Ticker
    {
        [JsonProperty(PropertyName = "buy")]
        public decimal buy;

        [JsonProperty(PropertyName = "sell")]
        public decimal sell;

        [JsonProperty(PropertyName = "low")]
        public decimal low;

        [JsonProperty(PropertyName = "high")]
        public decimal high;

        [JsonProperty(PropertyName = "last")]
        public decimal last;

        [JsonProperty(PropertyName = "vol")]
        public decimal vol;

        [JsonProperty(PropertyName = "amount")]
        public decimal amount;
    }
}