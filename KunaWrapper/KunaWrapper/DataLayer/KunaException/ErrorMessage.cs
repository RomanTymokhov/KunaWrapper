using Newtonsoft.Json;

namespace KunaWrapper.DataLayer.KunaException
{
    public class Error
    {
        [JsonProperty("error")]
        public ErrorMessage ErrorMessage { get; set; }
    }

    public class ErrorMessage
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
