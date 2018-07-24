using System;
using Newtonsoft.Json;
using KunaWrapper.DataLayer.Enums;
using System.Globalization;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Trade
    {
        [JsonProperty("id")]
        public uint TradeId { get; set; }

        [JsonProperty("price")]
        private readonly string price;
        public decimal CoinPrice => price != null ? Convert.ToDecimal(price, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("volume")]
        private readonly string volume;
        public decimal BaseVolume => volume != null ? Convert.ToDecimal(volume, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("funds")]
        private readonly string funds;
        public decimal RelativeVolume => funds != null ? Convert.ToDecimal(funds, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("market")]
        public MarketPair MarketPair { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("side")]
        private readonly string side;
        public OrderSide OrderSide => GetOrderSide(side);

        public uint GetUnixTime()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = CreatedTime - origin;
            return (uint)Math.Floor(diff.TotalSeconds);
        }

        private OrderSide GetOrderSide(string side)
        {
           switch(side)
            {
                case "buy": return OrderSide.buy; 
                case "sell": return OrderSide.sell;
                case "bid": return OrderSide.bid;
                case "ask": return OrderSide.ask;
                default: return OrderSide.noll;

            }
        }
    }
}