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
        public decimal CoinPrice
        {
            get
            {
                return price != null ? Convert.ToDecimal(price, CultureInfo.InvariantCulture) : -1;
            }
        }

        [JsonProperty("volume")]
        private readonly string volume;
        public decimal BaseVolume
        {
            get
            {
                return volume != null ? Convert.ToDecimal(volume, CultureInfo.InvariantCulture) : -1;
            }
        }

        [JsonProperty("funds")]
        private readonly string founds;
        public decimal RelativeVolume
        {
            get
            {
                return founds != null ? Convert.ToDecimal(founds, CultureInfo.InvariantCulture) : -1;
            }
        }

        [JsonProperty("market")]
        public MarketPair MarketPair { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedTime { get; set; }

        //[JsonProperty(PropertyName = "side")]
        //public OrderSide side = null;

        public uint GetUnixTime()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = CreatedTime - origin;
            return (uint)Math.Floor(diff.TotalSeconds);
        }
    }
}