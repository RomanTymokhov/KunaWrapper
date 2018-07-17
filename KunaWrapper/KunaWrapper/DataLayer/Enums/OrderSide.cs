﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KunaWrapper.DataLayer.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderSide
    {
        buy,
        sell,
        bid,
        ask,
        noll
    }
}
