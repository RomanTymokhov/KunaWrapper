using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using KunaWrapper.DataLayer.Enums;

namespace CunaWrapper.DataLevel.RciveData
{
    public class OrderBook
    {
        [JsonProperty(PropertyName = "asks")]
        public List<Order> asks;

        [JsonProperty(PropertyName = "bids")]
        public List<Order> bids;
    }

    public class Order
    {
        [JsonProperty(PropertyName = "id")]
        public uint orderId;

        [JsonProperty(PropertyName = "side")]
        public OrderSide side;

        [JsonProperty(PropertyName = "ord_type")]
        public OrderType orderType;

        [JsonProperty(PropertyName = "price")]
        public decimal price;

        [JsonProperty(PropertyName = "avg_price")]
        public decimal avg_price;

        [JsonProperty(PropertyName = "state")]
        public OrderState orderState;

        [JsonProperty(PropertyName = "market")]
        public MarketPair marketPair;

        [JsonProperty(PropertyName = "created_at")]
        public DateTime createdAt;

        [JsonProperty(PropertyName = "volume")]
        public decimal volume;

        [JsonProperty(PropertyName = "remaining_volume")]
        public decimal remainingVolume;

        [JsonProperty(PropertyName = "executed_volume")]
        public decimal executedVolume;

        [JsonProperty(PropertyName = "trades_count")]
        public uint tradesCount;
    }
}