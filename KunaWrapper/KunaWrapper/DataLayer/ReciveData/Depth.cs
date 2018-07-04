using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Depth
    {
        [JsonProperty(PropertyName = "timestamp")]
        public int timestamp;

        [JsonProperty(PropertyName = "asks")]
        public List<KeyValuePair<string, string>> asks;

        [JsonProperty(PropertyName = "bids")]
        public List<KeyValuePair<string, string>> bids;
    }
}
