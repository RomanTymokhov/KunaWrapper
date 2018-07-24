﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace KunaWrapper.DataLayer.ReciveData
{
    public class Holder
    {
        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("activated")]
        public bool IsAktivated { get; private set; }

        [JsonProperty("accounts")]
        public List<Assets> Assetses { get; private set; }
    }

    public class Assets
    {
        [JsonProperty("currency")]
        public string Currency { get; private set; }

        [JsonProperty("balance")]
        private readonly string ballance;
        public decimal Ballance => ballance != null ? Convert.ToDecimal(ballance, CultureInfo.InvariantCulture) : -1 ;

        [JsonProperty("locked")]
        private readonly string lockedSum;
        public decimal LockedSum => ballance != null ? Convert.ToDecimal(lockedSum, CultureInfo.InvariantCulture) : -1;
    }
}
