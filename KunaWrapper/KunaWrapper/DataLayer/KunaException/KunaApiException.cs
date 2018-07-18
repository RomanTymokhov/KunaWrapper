using System;

namespace KunaWrapper.DataLayer.KunaException
{
    public class KunaApiException : Exception
    {
        public KunaApiException() { }

        public KunaApiException(string message) : base(message) { }

        public KunaApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
