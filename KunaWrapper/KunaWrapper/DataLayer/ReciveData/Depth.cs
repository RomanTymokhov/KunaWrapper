using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Depth
    {
        public List<DepthItem> Asks = new List<DepthItem>();
        public List<DepthItem> Bids = new List<DepthItem>();

        [JsonProperty("timestamp")]
        public ulong Timestamp { get; private set; }

        [JsonProperty("asks")]
        private List<List<string>> ComingAsks
        {
            set
            {
                foreach (var item in value)
                {
                    if (item != null) Asks.Add(new DepthItem(item));
                }
            }
        }

        [JsonProperty("bids")]
        private List<List<string>> ComingBids
        {
            set
            {
                foreach (var item in value)
                {
                    if (item != null) Bids.Add(new DepthItem(item));
                }
            }
        }
    }

    public class DepthItem
    {
        public readonly decimal rate;
        public readonly decimal amount;

        public DepthItem(List<string> lst)
        {
            decimal.TryParse(lst[0], Any, InvariantCulture, out rate);
            decimal.TryParse(lst[1], Any, InvariantCulture, out amount);
        }
    }
}
