using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestObjectCancelOrder : RequestObject
    {
        public RequestObjectCancelOrder(string pubKey, string secKey, long tonce, uint orderId) : base(pubKey, secKey, tonce)
        {
            RequestArgs["id"] = orderId.ToString();

            GenerateRequest("POST", KunaMethod.CancelOrder);
        }
    }
}
