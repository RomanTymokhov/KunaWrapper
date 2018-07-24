using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Depth
    {
        [JsonProperty("timestamp")]
        public long timestamp;

        [JsonProperty("asks")]
        private readonly List<List<string>> asks;
        public List<List<decimal>> Asks => ConvertToDecimal(asks);

        [JsonProperty("bids")]
        private readonly List<List<string>> bids;
        public List<List<decimal>> Bids => ConvertToDecimal(bids);

        //потом может как-то оптимизировать
        private List<List<decimal>> ConvertToDecimal(List<List<string>> depthList)
        {
            var list = new List<List<decimal>>();

            foreach (var depth in depthList)
            {
                for (int i = 0; i < depth.Count; i++)
                {
                    list.Add(new List<decimal>
                    {
                        depth[0] != null ? Convert.ToDecimal(depth[0], CultureInfo.InvariantCulture) : -1,
                        depth[1] != null ? Convert.ToDecimal(depth[1], CultureInfo.InvariantCulture) : -1
                    });
                }
            }

            return list;
        }
    }
}
