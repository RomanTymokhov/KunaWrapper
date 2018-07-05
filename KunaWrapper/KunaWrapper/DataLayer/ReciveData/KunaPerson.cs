using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class KunaPerson
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; private set; }

        [JsonProperty(PropertyName = "activated")]
        public bool IsAktivated { get; private set; }

        [JsonProperty(PropertyName = "accounts")]
        public List<Assets> Assetses { get; private set; }

    }

    public class Assets
    {
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; private set; }

        [JsonProperty(PropertyName = "balance")]
        public decimal Ballans { get; private set; }

        [JsonProperty(PropertyName = "locked")]
        public decimal LockedSum { get; private set; }
    }
}
