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
        public List<List<decimal>> asks;

        [JsonProperty(PropertyName = "bids")]
        public List<List<decimal>> bids;
    }
}
