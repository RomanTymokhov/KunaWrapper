using Newtonsoft.Json;
using System;
using System.Globalization;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class TickerLine
    {
        [JsonProperty("at")]
        public ulong ServerTime { get; set; }

        [JsonProperty("ticker")]
        public Ticker ticker;
    }

    public class Ticker
    {
        [JsonProperty("buy")]        
        private readonly string buy;    // ели вдруг придет null - запишем -1;
        public decimal BuyPrice => buy != null ? Convert.ToDecimal(buy, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("sell")]
        private readonly string sell;
        public decimal SellPrice => sell != null ? Convert.ToDecimal(sell, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("low")]
        private readonly string low;
        public decimal MinPricePerDay => low != null ? Convert.ToDecimal(low, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("high")]
        private readonly string high;
        public decimal MaxPricePerDay => high != null ? Convert.ToDecimal(high, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("last")]
        private readonly string last;
        public decimal LastOperationPrice => last != null ? Convert.ToDecimal(last, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("vol")]
        private readonly string vol;
        public decimal CoinVolumePerDay => vol != null ? Convert.ToDecimal(vol, CultureInfo.InvariantCulture) : -1;

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal AmountVolumePerDay => amount != null ? Convert.ToDecimal(amount, CultureInfo.InvariantCulture) : -1;
    }
}