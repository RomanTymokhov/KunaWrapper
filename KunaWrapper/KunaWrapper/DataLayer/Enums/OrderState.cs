using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KunaWrapper.DataLayer.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderState
    {
        wait
    }
}
