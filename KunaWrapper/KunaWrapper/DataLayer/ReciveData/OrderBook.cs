using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Collections.Generic;
using KunaWrapper.DataLayer.Enums;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class OrderBook
    {
        [JsonProperty("asks")]
        public List<Order> Asks { get; set; }

        [JsonProperty("bids")]
        public List<Order> Bids { get; set; }
    }

    public class Order
    {
        [JsonProperty("id")]
        public uint OrderId { get; set; }

        [JsonProperty("side")]
        public OrderSide OrderSide { get; set; }

        [JsonProperty("ord_type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("price")]
        private readonly string price;
        public decimal CoinPrice => price != null ? Convert.ToDecimal(price, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("avg_price")]
        private readonly string avg_price;       // средняя цена по ордеру
        public decimal AveragePrice => avg_price != null ? Convert.ToDecimal(avg_price, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("state")]
        public OrderState OrderState { get; set; }

        [JsonProperty("market")]
        public MarketPair MarketPair { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("volume")]
        private readonly string volume;
        public decimal BaseVolume => volume != null ? Convert.ToDecimal(volume, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("remaining_volume")]
        private readonly string remainingVolume;
        public decimal RemaininVolume => remainingVolume != null ? Convert.ToDecimal(remainingVolume, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("executed_volume")]
        private readonly string executedVolume;
        public decimal ExeutedVolume => executedVolume != null ? Convert.ToDecimal(executedVolume, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("trades_count")]
        public ushort TradesCount { get; set; }
    }
}