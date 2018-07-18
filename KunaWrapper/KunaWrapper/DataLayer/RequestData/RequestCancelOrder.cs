using System;
using System.Collections.Generic;
using System.Text;

namespace KunaWrapper.DataLayer.RequestData
{
    internal class RequestCancelOrder : KunaRequest
    {
        public RequestCancelOrder(string pubKey, string secKey, long tonce, uint orderId) : base(pubKey, secKey, tonce)
        {
            RequestArgs["id"] = orderId.ToString();

            Url = "/api/v2/order/delete";

            GenerateRequest("POST");
        }

        public override string ToString()
        {
            return BuildRequestData(RequestArgs);
        }
    }
}
