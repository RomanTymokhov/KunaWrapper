using System;
using Newtonsoft.Json;
using KunaWrapper.DataLayer.Enums;

namespace CunaWrapper.DataLevel.RciveData
{
    public class Trade
    {
        [JsonProperty(PropertyName = "id")]
        public uint tradeId;

        [JsonProperty(PropertyName = "price")]
        public decimal price;

        [JsonProperty(PropertyName = "volume")]
        public decimal volume;

        [JsonProperty(PropertyName = "funds")]
        public decimal funds;

        [JsonProperty(PropertyName = "market")]
        public MarketPair marketPair;

        [JsonProperty(PropertyName = "created_at")]
        public DateTime createdAt;

        //[JsonProperty(PropertyName = "side")]
        //public OrderSide side = null;

        public int GetUnixTime()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = createdAt - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}