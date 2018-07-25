using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace KunaWrapper.DataLayer.KunaException
{
    public class KunaApiException : Exception
    {
        public KunaApiException() { }

        public KunaApiException(string message) : base(message) { }

        public KunaApiException(string message, Exception innerException) : base(message, innerException) { }

        public static void CheckException(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.NotFound)
                    throw new KunaApiException(response.ReasonPhrase);
                else
                {
                    var exception = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);

                    throw new KunaApiException("Ошибка подключения к Kuna:" +
                                                $"{Environment.NewLine} errorCode: {exception.ErrorMessage.Code} " +
                                                $"{Environment.NewLine} errorMessage: {exception.ErrorMessage.Message}");
                }
            }
        }
    }
}
