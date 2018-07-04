using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KunaWrapper.DataLayer.Enums
{
    //При добавлении новой пары на биржу сюда добавляется его тикер

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MarketPair
    {
        btcuah,
        ethuah,
        xrpuah,
        ltcuah,
        zecuah,
        dashuah,
        bchuah,
        xlmuah,
        gbguah,
        eosuah,
        tusduah,
        wavesuah,
        xemuah,
        krbuah,
        remuah,
        remeth,
        bchbtc
    }
}
