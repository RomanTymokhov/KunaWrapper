using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        [JsonProperty("currency")]
        public string Currency { get; private set; }

        [JsonProperty("balance")]
        private readonly string ballance;
        public decimal Ballance
        {
            get
            {
                return ballance != null ? Convert.ToDecimal(ballance, CultureInfo.InvariantCulture) : -1 ;
            }
        }

        [JsonProperty("locked")]
        private readonly string lockedSum;
        public decimal LockedSum
        {
            get
            {
                return ballance != null ? Convert.ToDecimal(lockedSum, CultureInfo.InvariantCulture) : -1;
            }
        }


    }
}
