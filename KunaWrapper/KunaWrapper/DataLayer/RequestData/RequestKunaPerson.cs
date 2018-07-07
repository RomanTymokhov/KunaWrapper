using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestKunaPerson : RequestObject
    {
        public RequestKunaPerson(string pubKey, int tonce) : base(pubKey, tonce)
        {
            GenerateSignature("POST", KunaMethods.KunaPerson);
        }
    }
}
