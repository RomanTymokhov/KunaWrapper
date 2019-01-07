using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Holder
    {
        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("activated")]
        public bool IsAktivated { get; private set; }

        [JsonProperty("accounts")]
        public List<Assets> Assets { get; private set; }
    }

    public class Assets
    {
        [JsonProperty("currency")]
        public string CurrencyId { get; private set; }
        
        private readonly decimal balance;
        public decimal Ballance => balance;
        
        private readonly decimal locked;
        public decimal LockedSum => locked;

        [JsonConstructor]
        public Assets(string balance, string locked)
        {
            decimal.TryParse(balance, Any, InvariantCulture, out this.balance);
            decimal.TryParse(locked,  Any, InvariantCulture, out this.locked);
        }
    }
}
