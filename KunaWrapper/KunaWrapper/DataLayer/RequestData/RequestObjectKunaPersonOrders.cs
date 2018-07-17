using KunaWrapper.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestObjectKunaPersonOrders : RequestObject
    {
        public RequestObjectKunaPersonOrders(string pubKey, string secKey, long tonce, MarketPair pair) : base(pubKey, secKey, tonce)
        {
            RequestArgs["market"] = pair.ToString();

            GenerateRequest("GET", KunaMethod.KunaPersonOrders);
        }
    }
}
