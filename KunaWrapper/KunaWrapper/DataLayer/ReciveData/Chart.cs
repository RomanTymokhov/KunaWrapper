using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    [JsonArray]
    public class Chart
    {
        public List<Candle> Candles { get; private set; }

        [JsonConstructor]
        public Chart(List<object> incomingObject)
        {
            Candles = new List<Candle>();
            foreach (JArray item in incomingObject)
            {
                Candles.Add(new Candle(item));
            }
        }
    }

    public class Candle
    {
        private readonly uint timestamp;
        public uint OpenTime => timestamp;

        private readonly decimal openPrice;
        public decimal OpenPrice => openPrice;

        private readonly decimal maxPrice;
        public decimal MaxPrice => maxPrice;

        private readonly decimal minPrice;
        public decimal MinPrice => minPrice;

        private readonly decimal closePrice;
        public decimal ClosePrice => closePrice;

        private readonly decimal volume;
        public decimal Volume => volume;
        
        public Candle(JArray array)
        {
            uint.TryParse(array[0].ToObject<string>(), out timestamp);
            decimal.TryParse(array[1].ToObject<string>(), Any, InvariantCulture, out openPrice);
            decimal.TryParse(array[2].ToObject<string>(), Any, InvariantCulture, out maxPrice);
            decimal.TryParse(array[3].ToObject<string>(), Any, InvariantCulture, out minPrice);
            decimal.TryParse(array[4].ToObject<string>(), Any, InvariantCulture, out closePrice);
            decimal.TryParse(array[5].ToObject<string>(), Any, InvariantCulture, out volume);
        }
    }
}
