using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestObjectKunaPerson : RequestObject
    {
        public RequestObjectKunaPerson(string pubKey, string secKey, long tonce) : base(pubKey, secKey, tonce)
        {
            GenerateRequest("GET", KunaMethod.KunaPerson);
        }
    }
}
