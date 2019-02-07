using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace KunaWrapper.DataLayer.KunaException
{
    public class KunaException : Exception
    {
        public KunaException() { }

        public KunaException(string message) : base(message) { }

        public KunaException(string message, Exception innerException) : base(message, innerException) { }

        public static void CheckException(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Forbidden || 
                response.StatusCode == HttpStatusCode.NotFound  || 
                response.StatusCode == HttpStatusCode.MethodNotAllowed)
                throw new KunaException(response.ReasonPhrase);
            else
            {
                var exception = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);

                throw new KunaException("Ошибка подключения к Kuna:" +
                                            $"{Environment.NewLine} errorCode: {exception.ErrorMessage.Code} " +
                                            $"{Environment.NewLine} errorMessage: {exception.ErrorMessage.Message}");
            }            
        }
    }
}
