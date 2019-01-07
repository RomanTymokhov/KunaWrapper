using System;
using Newtonsoft.Json;
using System.Collections.Generic;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class OrderBook
    {
        [JsonProperty("asks")]
        public List<Order> Asks { get; private set; }

        [JsonProperty("bids")]
        public List<Order> Bids { get; private set; }
    }

    public class Order
    {
        [JsonProperty("id")]
        public uint OrderId { get; private set; }

        [JsonProperty("side")]
        public string OrderSide { get; private set; }

        [JsonProperty("ord_type")]
        public string OrderType { get; private set; }
        
        private readonly decimal price;
        public decimal CoinPrice => price;
        
        private readonly decimal avgPrice;  
        public decimal AveragePrice => avgPrice;

        [JsonProperty("state")]
        public string OrderState { get; private set; }

        [JsonProperty("market")]
        public string MarketPair { get; private set; }

        [JsonProperty("created_at")]
        public DateTime CreatedTime { get; private set; }  //check responce this fild
        
        private readonly decimal volume;
        public decimal BaseVolume => volume;
        
        private readonly decimal remainingVolume;
        public decimal RemaininVolume => remainingVolume;

        private readonly decimal executedVolume;
        public decimal ExeutedVolume => executedVolume;

        [JsonProperty("trades_count")]
        public ushort TradesCount { get; private set; }

        [JsonConstructor]
        public Order(string price, string avg_price, string volume, string remaining_volume, string executed_volume)
        {
            decimal.TryParse(price,  Any, InvariantCulture, out this.price);
            decimal.TryParse(volume, Any, InvariantCulture, out this.volume);
            decimal.TryParse(avg_price, Any, InvariantCulture, out avgPrice);
            decimal.TryParse(remaining_volume, Any, InvariantCulture, out remainingVolume);
            decimal.TryParse(executed_volume,  Any, InvariantCulture, out executedVolume);
        }
    }
}