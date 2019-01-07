using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class TickerLine
    {
        [JsonProperty("at")]
        public ulong ServerTime { get; private set; }

        [JsonProperty("ticker")]
        public Ticker Ticker { get; private set; }
    }

    public class Ticker
    {
        private readonly decimal buy;
        public decimal BuyPrice => buy;
        
        private readonly decimal sell;
        public decimal SellPrice => sell;
        
        private readonly decimal low;
        public decimal MinPricePerDay => low;
        
        private readonly decimal high;
        public decimal MaxPricePerDay => high;
        
        private readonly decimal last;
        public decimal LastOperationPrice => last;
        
        private readonly decimal vol;
        public decimal CoinVolumePerDay => vol;
        
        private readonly decimal amount;
        public decimal AmountVolumePerDay => amount;

        [JsonConstructor]
        public Ticker(string buy, string sell, string low, string high, string last, string vol, string amount)
        {
            decimal.TryParse(buy,   Any, InvariantCulture, out this.buy);
            decimal.TryParse(sell,  Any, InvariantCulture, out this.sell);
            decimal.TryParse(low,   Any, InvariantCulture, out this.low);
            decimal.TryParse(high,  Any, InvariantCulture, out this.high);
            decimal.TryParse(last,  Any, InvariantCulture, out this.last);
            decimal.TryParse(vol,   Any, InvariantCulture, out this.vol);
            decimal.TryParse(amount,Any, InvariantCulture, out this.amount);
        }
    }
}