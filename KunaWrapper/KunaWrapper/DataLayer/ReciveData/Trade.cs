using System;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Trade
    {
        [JsonProperty("id")]
        public uint TradeId { get; private set; }
        
        private readonly decimal price;
        public decimal Price => price;
        
        private readonly decimal volume;
        public decimal BaseVolume => volume;
        
        private readonly decimal funds;
        public decimal QuotedVolume => funds;

        [JsonProperty("market")]
        public string PairId { get; private set; }

        [JsonProperty("created_at")]
        public DateTime CreatedTime { get; private set; }  //check responce this fild

        [JsonProperty("side")]
        public string OrderSide { get; private set; }

        [JsonConstructor]
        public Trade(string price, string volume, string funds)
        {
            decimal.TryParse(price,  Any, InvariantCulture, out this.price);
            decimal.TryParse(volume, Any, InvariantCulture, out this.volume);
            decimal.TryParse(funds,  Any, InvariantCulture, out this.funds);
        }
    }
}